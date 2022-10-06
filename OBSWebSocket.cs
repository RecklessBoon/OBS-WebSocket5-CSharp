using OBSWebSocket5.Frames;
using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OBSWebSocket5.Frames.HelloFrameData;
using static OBSWebSocket5.OBSWebSocket.MessageDispatcher;

namespace OBSWebSocket5
{
    public partial class OBSWebSocket : IDisposable
    {
        protected int _BufferSize = 1024 * 6;

        protected bool _IsDisposed = false;
        public bool IsDisposed => _IsDisposed;
        protected Uri _Address { get; set; }
        protected CancellationTokenSource _CTS { get; set; }
        protected ClientWebSocket _WebSocket { get; set; }
        protected OBSWebSocketAuth _Auth { get; set; }
        protected MessageDispatcher _Dispatcher;
        public MessageDispatcher Dispatcher { get => _Dispatcher; }

        protected bool _IsConnected = false;
        public bool IsConnected => _IsConnected;

        public event EventHandler<EventArgs> Connected;
        public event EventHandler<EventArgs> Disposed;

        public OBSWebSocket()
        {
            _CTS = CreateCancellationTokenSource(default);
            _Dispatcher = new MessageDispatcher(this);
            InitRequestServices();
            InitEventServices();
        }

        protected CancellationTokenSource CreateCancellationTokenSource(CancellationToken token) =>
            (token == default ? new CancellationTokenSource() : CancellationTokenSource.CreateLinkedTokenSource(token));

        public static async Task<bool> IsInstalledAndOpenAsync(Uri address, CancellationToken token, int timeoutMilliseconds = 10000)
        {
            using var obs = new OBSWebSocket();
            obs._WebSocket = new ClientWebSocket();
            obs._WebSocket.Options.SetBuffer(obs._BufferSize, obs._BufferSize);

            var testCompletion = new TaskCompletionSource<bool>();

            // Wait for Hello and send Indentify
            EventHandler<FrameEventArgs> helloHandler = default;
            helloHandler = (sender, args) =>
            {
                var helloFrame = args.Frame.Data.ToObject<HelloFrameData>();
                var isV5 = helloFrame.ObsWebSocketVersion.StartsWith("5.");
                obs._Dispatcher.HelloReceived -= helloHandler;
                testCompletion.SetResult(isV5);
            };
            obs._Dispatcher.HelloReceived += helloHandler;

            await obs._WebSocket.ConnectAsync(address, token);
            _ = obs._Dispatcher.BeginProcessingAsync();
            if (await Task.WhenAny(testCompletion.Task, Task.Delay(timeoutMilliseconds)) == testCompletion.Task)
            {
                return await testCompletion.Task;
            }
            else
            {
                return false;
            }
        }

        protected string HashPassword(AuthCrypt cryptography, string pass)
        {
            var salted = pass + cryptography.Salt;
            using SHA256 hash = SHA256.Create();
            var base64Secret = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(salted)));
            var challenged = base64Secret + cryptography.Challenge;
            var authString = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(challenged)));
            return authString;
        }

        public async Task ConnectAsync(Uri address, OBSWebSocketAuth auth = null, CancellationToken token = default)
        {
            _Address = address;
            _Auth = auth ?? new OBSWebSocketAuthNone();
            _CTS = CreateCancellationTokenSource(token);
            _WebSocket = new ClientWebSocket();
            _WebSocket.Options.SetBuffer(_BufferSize, _BufferSize);

            var authCompletion = new TaskCompletionSource<bool>();

            // Wait for Hello and send Indentify
            EventHandler<FrameEventArgs> helloHandler = default;
            helloHandler = (sender, args) =>
            {
                var helloFrame = args.Frame?.Data.ToObject<HelloFrameData>();
                if (helloFrame == null) return;
                var rpcVersion = helloFrame.RpcVersion;
                if (auth is OBSWebSocketAuthPassword)
                {
                    var cryptography = helloFrame.Authentication;
                    var pass = (auth as OBSWebSocketAuthPassword).Password;
                    var authString = HashPassword(cryptography, pass);
                    _ = _Dispatcher.NotifyAsync(new IdentifyFrameData()
                    {
                        RpcVersion = rpcVersion,
                        Authentication = authString,
                    });
                }
                else
                {
                    _ = _Dispatcher.NotifyAsync(new IdentifyFrameData() { RpcVersion = rpcVersion });
                }
                _Dispatcher.HelloReceived -= helloHandler;
            };
            _Dispatcher.HelloReceived += helloHandler;

            EventHandler<FrameEventArgs> identifiedHandler = default;
            identifiedHandler = (sender, args) =>
            {
                authCompletion.SetResult(true);
                _Dispatcher.IdentifiedReceived -= identifiedHandler;
            };
            _Dispatcher.IdentifiedReceived += identifiedHandler;


            await _WebSocket.ConnectAsync(_Address, _CTS.Token);
            _ = Task.Run(async () =>
            {
                await _Dispatcher.BeginProcessingAsync();
                Dispose();
            });
            _IsConnected = await authCompletion.Task;
            Connected?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                _IsConnected = false;
                _CTS?.Cancel();
                _WebSocket?.Dispose();
                _IsDisposed = true;
                Disposed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

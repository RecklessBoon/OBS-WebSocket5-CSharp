using Newtonsoft.Json;
using OBSWebSocket5.Enum;
using OBSWebSocket5.Frames;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5
{
    public partial class OBSWebSocket
    {
        public class MessageDispatcher
        {
            public class FrameEventArgs : EventArgs
            {
                public FrameEventArgs(Frame frame)
                {
                    Frame = frame;
                }

                public Frame Frame { get; set; }
            }

            public event EventHandler<FrameEventArgs> FrameReceived;
            public event EventHandler<FrameEventArgs> HelloReceived;
            public event EventHandler<FrameEventArgs> IdentifyReceived;
            public event EventHandler<FrameEventArgs> IdentifiedReceived;
            public event EventHandler<FrameEventArgs> ReidentifyReceived;
            public event EventHandler<FrameEventArgs> EventReceived;
            public event EventHandler<FrameEventArgs> RequestResponseReceived;
            public event EventHandler<FrameEventArgs> RequestBatchResponseReceived;

            protected OBSWebSocket _OBS;
            protected bool _ShouldProcess = true;

            public MessageDispatcher(OBSWebSocket obs) => _OBS = obs;

            public async Task BeginProcessingAsync()
            {
                var _ws = _OBS._WebSocket;
                while (_ws.State == WebSocketState.Open && _ShouldProcess)
                {
                    try
                    {
                        WebSocketReceiveResult result;
                        var buffer = new byte[_OBS._BufferSize];
                        var offset = 0;
                        var free = buffer.Length;
                        do
                        {
                            try
                            {
                                result = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer, offset, free), _OBS._CTS.Token);
                                offset += result.Count;
                                free -= result.Count;
                                if (result.EndOfMessage) break;
                                if (free == 0)
                                {
                                    var newSize = buffer.Length + _OBS._BufferSize;
                                    if (newSize > 2000000000)
                                    {
                                        throw new Exception("Maximum size exceeded");
                                    }

                                    var newBuffer = new byte[newSize];
                                    Array.Copy(buffer, 0, newBuffer, 0, offset);
                                    buffer = newBuffer;
                                    free = buffer.Length - offset;
                                }
                            }
                            catch (OperationCanceledException)
                            {
                                break;
                            }
                        } while (!result.EndOfMessage);

                        _ = Task.Run(() => ProcessMessage(buffer));
                    }
                    catch (OperationCanceledException) { break; }
                }
            }

            public void ProcessMessage(byte[] readBuffer)
            {
                var json = Encoding.UTF8.GetString(readBuffer).TrimEnd('\0');
                if (json.Equals(String.Empty)) return;

                var frame = JsonConvert.DeserializeObject<Frame>(json);
                var frameEventArgs = new FrameEventArgs(frame);
                FrameReceived?.Invoke(this, frameEventArgs);

                switch (frame.Opcode)
                {
                    case WebSocketOpCode.Hello:
                        HelloReceived?.Invoke(this, frameEventArgs);
                        break;
                    case WebSocketOpCode.Identify:
                        IdentifyReceived?.Invoke(this, frameEventArgs);
                        break;
                    case WebSocketOpCode.Identified:
                        IdentifiedReceived?.Invoke(this, frameEventArgs);
                        break;
                    case WebSocketOpCode.Reidentify:
                        ReidentifyReceived?.Invoke(this, frameEventArgs);
                        break;
                    case WebSocketOpCode.Event:
                        EventReceived?.Invoke(this, frameEventArgs);
                        break;
                    case WebSocketOpCode.RequestResponse:
                        RequestResponseReceived?.Invoke(this, frameEventArgs);
                        break;
                    case WebSocketOpCode.RequestBatchResponse:
                        RequestBatchResponseReceived?.Invoke(this, frameEventArgs);
                        break;
                }
            }

            public Task EndProcessingAsync()
            {
                return Task.Run(() => _ShouldProcess = false);
            }

            protected async Task WriteAsync(string message)
            {
                ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
                Console.Write("\nSending:\n{0}\n", Encoding.UTF8.GetString(bytesToSend));
                await _OBS._WebSocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, _OBS._CTS.Token);
            }

            public Task NotifyAsync(RequestFrameData message) {
                message.RequestId ??= Guid.NewGuid().ToString();
                return NotifyAsync(message.ToFrame());
            }

            public Task NotifyAsync(FrameData message) => NotifyAsync(message.ToFrame());

            public Task NotifyAsync(object message) => WriteAsync(JsonConvert.SerializeObject(message));

            public Task NotifyAsync(string message) => WriteAsync(message);

            public async Task<FrameEventArgs> SendAsync(RequestFrameData requestFrame)
            {
                requestFrame.RequestId ??= Guid.NewGuid().ToString();

                var completion = new TaskCompletionSource<FrameEventArgs>();
                EventHandler<FrameEventArgs> handler = default;
                handler = (object _dispatcher, FrameEventArgs args) =>
                {
                    if (args.Frame.Opcode != WebSocketOpCode.RequestResponse ||
                        args.Frame.Data.ToObject<RequestResponseFrameData>().RequestId != requestFrame.RequestId) return;

                    FrameReceived -= handler;
                    completion.SetResult(args);
                };
                FrameReceived += handler;
                _ = NotifyAsync(requestFrame);
                return await completion.Task;
            }

            public async Task<T> SendAsync<T>(RequestFrameData requestFrame)
            {
                var response = await SendAsync(requestFrame);
                var data = response.Frame.Data["responseData"];
                return data != null ? data.ToObject<T>() : default(T);
            }

            protected Dictionary<string, List<EventHandler<FrameEventArgs>>> handlers = new Dictionary<string, List<EventHandler<FrameEventArgs>>>();

            public void Subscribe(string event_name, EventHandler callback)
            {
                if (!handlers.ContainsKey(event_name))
                {
                    handlers.Add(event_name, new List<EventHandler<FrameEventArgs>>());
                }

                EventHandler<FrameEventArgs> handler = delegate (object sender, FrameEventArgs e)
                {
                    var result = e.Frame.Data.ToObject<EventFrameData>();
                    if (result.EventType == event_name)
                    {
                        callback?.Invoke(_OBS, EventArgs.Empty);
                    }
                };
                handlers[event_name].Add(handler);
                EventReceived -= handler;
                EventReceived += handler;
            }

            public void Subscribe<T>(string event_name, EventHandler<T> callback)
            {
                if (!handlers.ContainsKey(event_name))
                {
                    handlers.Add(event_name, new List<EventHandler<FrameEventArgs>>());
                }

                EventHandler<FrameEventArgs> handler = delegate (object sender, FrameEventArgs e)
                {
                    var result = e.Frame.Data.ToObject<EventFrameData>();
                    if (result.EventType == event_name)
                    {
                        var obj = result.EventData.ToObject<T>();
                        callback?.Invoke(_OBS, obj);
                    }
                };
                handlers[event_name].Add(handler);
                EventReceived -= handler;
                EventReceived += handler;
            }

            public void Unsubscribe(string event_name)
            {
                var handler_list = handlers[event_name];
                foreach (var handler in handler_list)
                {
                    EventReceived -= handler;
                }

                handlers.Remove(event_name);
            }
        }
    }
}

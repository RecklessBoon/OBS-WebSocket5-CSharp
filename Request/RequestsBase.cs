using OBSWebSocket5.Frames;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static OBSWebSocket5.OBSWebSocket;

namespace OBSWebSocket5.Request
{
    public class RequestsBase
    {
        public MessageDispatcher _Dispatcher;

        public RequestsBase(MessageDispatcher dispatcher)
        {
            _Dispatcher = dispatcher;
        }

        public object[] ArgsArray(params object[] args) => args;

        public async Task MakeCallAsync([CallerMemberName] string method = "") => await MakeCallAsync(null, method);

        public async Task MakeCallAsync(object arg, [CallerMemberName] string method = "")
        {
            if (_Dispatcher == null) return;

            await _Dispatcher.NotifyAsync(new RequestFrameData
            {
                RequestType = method.Replace("Async", ""),
                RequestData = arg
            });
        }

        public async Task<T> MakeCallAsync<T>([CallerMemberName] string method = "") => await MakeCallAsync<T>(null, method);

        public async Task<T> MakeCallAsync<T>(object arg, [CallerMemberName] string method = "")
        {
            if (_Dispatcher == null) return default;

            return await _Dispatcher.SendAsync<T>(new RequestFrameData
            {
                RequestType = method.Replace("Async", ""),
                RequestData = arg
            });
        }
    }
}

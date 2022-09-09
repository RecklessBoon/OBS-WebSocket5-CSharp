using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class RequestFrameData : FrameData, IRequestTransaction
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.Request;

        public string RequestType { get; set; }
        public string RequestId { get; set; }
        public object RequestData { get; set; }
    }
}

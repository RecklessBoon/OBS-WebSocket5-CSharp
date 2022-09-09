using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class RequestResponseFrameData : FrameData, IRequestTransaction
    {
        public class RequestStatusType
        {
            public bool Result { get; set; }
            public RequestStatus Code { get; set; }
            public string Comment { get; set; }
        }

        protected override WebSocketOpCode OpCode => WebSocketOpCode.RequestResponse;

        public string RequestType { get; set; }
        public string RequestId { get; set; }
        public RequestStatusType RequestStatus { get; set; }
        public object RequestData { get; set; }
    }
}

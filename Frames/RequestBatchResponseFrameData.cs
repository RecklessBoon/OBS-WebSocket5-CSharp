using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class RequestBatchResponseFrameData : FrameData, IRequestBatchTransaction
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.RequestBatchResponse;

        public string RequestId { get; set; }
        public JObject[] Results { get; set; }
    }
}

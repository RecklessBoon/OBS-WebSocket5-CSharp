using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class RequestBatchFrameData : FrameData, IRequestBatchTransaction
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.RequestBatch;

        public string RequestId { get; set; }
        public bool HaltOnFailture { get; set; } = false;
        public RequestBatchExecutionType ExecutionType { get; set; } = RequestBatchExecutionType.SerialRealtime;
        public RequestFrameData[] Requests { get; set; }
    }
}

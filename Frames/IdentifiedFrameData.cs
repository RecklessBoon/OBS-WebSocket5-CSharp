using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class IdentifiedFrameData : FrameData
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.Identified;

        public int NegotiatedRpcVersion { get; set; }
        
    }
}

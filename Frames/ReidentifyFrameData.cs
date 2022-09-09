using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class ReidentifyFrameData : FrameData
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.Reidentify;

        public EventSubscription EventSubscriptions { get; set; } = EventSubscription.All;
        
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class IdentifyFrameData : FrameData
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.Identify;

        public int RpcVersion { get; set; }
        public string Authentication { get; set; }
        public EventSubscription EventSubscriptions { get; set; } = EventSubscription.All;
        
    }
}

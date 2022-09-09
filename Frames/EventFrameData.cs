using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OBSWebSocket5.Enum;

namespace OBSWebSocket5.Frames
{
    public class EventFrameData : FrameData
    {
        protected override WebSocketOpCode OpCode => WebSocketOpCode.Event;

        public string EventType { get; set; }
        public int EventIntent { get; set; }
        public JObject EventData { get; set; }
        
    }
}

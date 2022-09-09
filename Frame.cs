using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;
using OBSWebSocket5.Frames;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5
{
    public class Frame
    {
        [JsonProperty("op")]
        public WebSocketOpCode Opcode { get; set; }

        [JsonProperty("d")]
        public JObject Data { get; set; }
    }
}

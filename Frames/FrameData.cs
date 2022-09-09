using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OBSWebSocket5.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Frames
{
    [JsonObject(
        NamingStrategyType = typeof(CamelCaseNamingStrategy),
        ItemNullValueHandling = NullValueHandling.Ignore
    )]
    public abstract class FrameData
    {
        [JsonIgnore]
        protected abstract WebSocketOpCode OpCode { get; }

        public Frame ToFrame()
        {
            return new Frame
            {
                Opcode = this.OpCode,
                Data = JObject.FromObject(this)
            };
        }
    }
}

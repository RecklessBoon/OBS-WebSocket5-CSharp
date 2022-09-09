using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Frames
{
    public interface IRequestTransaction
    {
        public string RequestType { get; set; }
        public string RequestId { get; set; }
        public object RequestData { get; set; }
    }
}

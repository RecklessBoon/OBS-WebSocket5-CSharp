using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Frames
{
    public interface IRequestBatchTransaction
    {
        public string RequestId { get; set; }
    }
}

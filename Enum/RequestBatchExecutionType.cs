using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Enum
{
    public enum RequestBatchExecutionType
    {
        None = -1,
        SerialRealtime = 0,
        SerialFrame = 1,
        Parallel = 2,
    }
}

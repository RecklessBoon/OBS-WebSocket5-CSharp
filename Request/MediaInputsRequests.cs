using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class MediaInputsRequests : RequestsBase
    {
        public MediaInputsRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetMediaInputsStatusResponse : ResponsesBase
        {
            public string MediaState { get; set; }
            public int? MediaDuration { get; set; }
            public int? MediaCursor { get; set; }
        }
        public Task<GetMediaInputsStatusResponse> GetMediaInputStatusAsync(string inputName) => 
            MakeCallAsync<GetMediaInputsStatusResponse>(new { inputName });

        public Task SetMediaInputCursorAsync(string inputName, int mediaCursor) => 
            MakeCallAsync(new { inputName, mediaCursor });

        public Task OffsetMediaInputCursorAsync(string inputName, int mediaCursorOffset) => 
            MakeCallAsync(new { inputName, mediaCursorOffset });

        public Task TriggerMediaInputActionAsync(string inputName, string mediaAction) => 
            MakeCallAsync(new { inputName, mediaAction });
    }
}

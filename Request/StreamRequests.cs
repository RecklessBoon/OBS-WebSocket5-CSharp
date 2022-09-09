using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class StreamRequests : RequestsBase
    {
        public StreamRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetStreamStatusResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
            public bool OutputReconnecting { get; set; }
            public string OutputTimecode { get; set; }
            public int OutputDuration { get; set; }
            public float OutputCongestion { get; set; }
            public int OutputBytes { get; set; }
            public int OutputSkippedFrames { get; set; }
            public int OutputTotalFrames { get; set; }
        }
        public Task<GetStreamStatusResponse> GetStreamStatusAsync() => 
            MakeCallAsync<GetStreamStatusResponse>();

        public class ToggleStreamResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
        }
        public Task<ToggleStreamResponse> ToggleStreamAsync() => 
            MakeCallAsync<ToggleStreamResponse>();

        public Task StartStreamAsync() => 
            MakeCallAsync();

        public Task StopStreamAsync() => 
            MakeCallAsync();

        public Task SendStreamCaptionAsync(string captionText) => 
            MakeCallAsync(new { captionText });
    }
}

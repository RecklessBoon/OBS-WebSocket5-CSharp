using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class RecordRequests : RequestsBase
    {
        public RecordRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetRecordStatusResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
            public bool OutputPaused { get; set; }
            public string OutputTimecode { get; set; }
            public int OutputDuration { get; set; }
            public int OutputBytes { get; set; }
        }
        public Task<GetRecordStatusResponse> GetRecordStatusAsync() => 
            MakeCallAsync<GetRecordStatusResponse>();

        public class ToggleRecordResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
        }
        public Task<ToggleRecordResponse> ToggleRecordAsync() => 
            MakeCallAsync<ToggleRecordResponse>();

        public Task StartRecordAsync() => 
            MakeCallAsync();

        public Task StopRecordAsync() => 
            MakeCallAsync();

        public Task ToggleRecordPauseAsync() => 
            MakeCallAsync();

        public Task PauseRecordAsync() => 
            MakeCallAsync();

        public Task ResumeRecordAsync() => 
            MakeCallAsync();
    }
}

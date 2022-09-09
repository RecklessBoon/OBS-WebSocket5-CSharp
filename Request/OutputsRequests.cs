using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class OutputsRequests : RequestsBase
    {
        public OutputsRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetVirtualCamStatusResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
        }
        public Task<GetVirtualCamStatusResponse> GetVirtualCamStatusAsync() => 
            MakeCallAsync<GetVirtualCamStatusResponse>();

        public class ToggleVirtualCamResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
        }
        public Task<ToggleVirtualCamResponse> ToggleVirtualCamAsync() => 
            MakeCallAsync<ToggleVirtualCamResponse>();

        public Task StartVirtualCamAsync() => 
            MakeCallAsync();

        public Task StopVirtualCamAsync() =>
            MakeCallAsync();

        public class GetReplayBufferStatusResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
        }
        public Task<GetReplayBufferStatusResponse> GetReplayBufferStatusAsync() => 
            MakeCallAsync<GetReplayBufferStatusResponse>();

        public class ToggleReplayBufferResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
        }
        public Task<ToggleReplayBufferResponse> ToggleReplayBufferAsync() => 
            MakeCallAsync<ToggleReplayBufferResponse>();

        public Task StartReplayBufferAsync() => 
            MakeCallAsync();

        public Task StopReplayBufferAsync() => 
            MakeCallAsync();

        public Task SaveReplayBufferAsync() => 
            MakeCallAsync();

        public class GetLastReplayBufferReplayResponse : ResponsesBase
        {
            public string SavedReplayPath { get; set; }
        }
        public Task<GetLastReplayBufferReplayResponse> GetLastReplayBufferReplayAsync() => 
            MakeCallAsync<GetLastReplayBufferReplayResponse>();

        public class GetOutputListResponse : ResponsesBase
        {
            public JObject[] Outputs { get; set; }
        }
        public Task<GetOutputListResponse> GetOutputListAsync() => 
            MakeCallAsync<GetOutputListResponse>();

        public class GetOutputStatusResponse : ResponsesBase
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
        public Task<GetOutputStatusResponse> GetOutputStatusAsync(string outputName) => 
            MakeCallAsync<GetOutputStatusResponse>(new { outputName });

        public class ToggleOutputResponse : ResponsesBase
        {
            public bool OutputActive { get; set; }
        }
        public Task<ToggleOutputResponse> ToggleOutputAsync(string outputName) => 
            MakeCallAsync<ToggleOutputResponse>(new { outputName });

        public Task StartOutputAsync(string outputName) => 
            MakeCallAsync(new { outputName });

        public Task StopOutputAsync(string outputName) => 
            MakeCallAsync(new { outputName });

        public class GetOutputSettingsResponse : ResponsesBase
        {
            public JObject OutputSettings { get; set; }
        }
        public Task<GetOutputSettingsResponse> GetOutputSettingsAsync(string outputName) => 
            MakeCallAsync<GetOutputSettingsResponse>(new { outputName });

        public Task SetOutputSettingsAsync(string outputName, object outputSettings) => 
            MakeCallAsync(new { outputName, outputSettings });
    }
}

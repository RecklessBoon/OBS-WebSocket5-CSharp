using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class UiRequests : RequestsBase
    {
        public UiRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetStudioModeEnabledResponse : ResponsesBase
        {
            public bool StudioModeEnabled { get; set; }
        }
        public Task<GetStudioModeEnabledResponse> GetStudioModeEnabledAsync() => 
            MakeCallAsync<GetStudioModeEnabledResponse>();

        public Task SetStudioModeEnabledAsync(bool studioModeEnabled) => 
            MakeCallAsync(new { studioModeEnabled });

        public Task OpenInputPropertiesDialogAsync(string inputName) => 
            MakeCallAsync(new { inputName });

        public Task OpenInputFiltesDialogAsync(string inputName) => 
            MakeCallAsync(new { inputName });

        public Task OpenInputInteractDialogAsync(string inputName) => 
            MakeCallAsync(new { inputName });

        public class GetMonitorListResponse : ResponsesBase
        {
            public JObject[] Monitors { get; set; }
        }
        public Task<GetMonitorListResponse> GetMonitorListAsync() => 
            MakeCallAsync<GetMonitorListResponse>();

        public Task OpenVideoMixProjectorAsync(VideoMixType videoMixTape,
                                               int? monitorIndex = null,
                                               string projectorGeometry = null) =>
            MakeCallAsync(new
            {
                videoMixTape,
                monitorIndex,
                projectorGeometry
            });

        public Task OpenSourceProjector(string sourceName,
                                        int? monitorIndex = null,
                                        string projectorGeometry = null) =>
            MakeCallAsync(new
            {
                sourceName,
                monitorIndex,
                projectorGeometry
            });
    }
}

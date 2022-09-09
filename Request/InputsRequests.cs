using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;
using OBSWebSocket5.Response;
using System;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class InputsRequests : RequestsBase
    {
        public InputsRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetInputListResponse : ResponsesBase
        {
            public JObject[] Inputs { get; set; }
        }
        public Task<GetInputListResponse> GetInputListAsync(string inputKind = null) => 
            MakeCallAsync<GetInputListResponse>(new { inputKind });

        public class GetInputKindListResponse : ResponsesBase
        {
            public string[] InputKinds { get; set; }
        }
        public Task<GetInputKindListResponse> GetInputKindListAsync(string unversioned = null) => 
            MakeCallAsync<GetInputKindListResponse>(new { unversioned });

        public class GetSpecialInputsResponse : ResponsesBase
        {
            public string Desktop1 { get; set; }
            public string Desktop2 { get; set; }
            public string Mic1 { get; set; }
            public string Mic2 { get; set; }
            public string Mic3 { get; set; }
            public string Mic4 { get; set; }
        }
        public Task<GetSpecialInputsResponse> GetSpecialInputsAsync() => 
            MakeCallAsync<GetSpecialInputsResponse>();

        public class CreateInputResponse : ResponsesBase
        {
            public int SceneItemId { get; set; }
        }
        public Task<CreateInputResponse> CreateInputAsync(string sceneName, 
                                                          string inputName, 
                                                          string inputKind, 
                                                          object inputSettings = null, 
                                                          bool? sceneItemEnabled = null) => 
            MakeCallAsync<CreateInputResponse>(new
            {
                sceneName,
                inputName,
                inputKind,
                inputSettings,
                sceneItemEnabled
            });

        public Task RemoveInputAsync(string inputName) => 
            MakeCallAsync(new { inputName });

        public Task SetInputNameAsync(string inputName, string newInputName) => 
            MakeCallAsync(new { inputName, newInputName });

        public class GetInputDefaultSettingsResponse : ResponsesBase
        {
            public string InputKind { get; set; }
        }
        public Task<GetInputDefaultSettingsResponse> GetInputDefaultSettingsAsync(string inputKind) => 
            MakeCallAsync<GetInputDefaultSettingsResponse>(new { inputKind });

        public class GetInputSettingsResponse : ResponsesBase
        {
            public JObject InputSettings { get; set; }
            public string InputKind { get; set; }
        }
        public Task<GetInputSettingsResponse> GetInputSettingsAsync(string inputName) => 
            MakeCallAsync<GetInputSettingsResponse>(new { inputName });

        public Task SetInputSettingsAsync(string inputName, object inputSettings, bool? overlay = null) => 
            MakeCallAsync(new { inputName, inputSettings, overlay });

        public class GetInputMuteResponse : ResponsesBase
        {
            public bool InputMuted { get; set; }
        }
        public Task<GetInputMuteResponse> GetInputMuteAsync(string inputName) => 
            MakeCallAsync<GetInputMuteResponse>(new { inputName });

        public Task SetInputMuteAsync(string inputName, bool inputMuted) => 
            MakeCallAsync(new { inputName, inputMuted });

        public class ToggleInputResponse : ResponsesBase
        {
            public bool InputMuted { get; set; }
        }
        public Task<ToggleInputResponse> ToggleInputMuteAsync(string inputName) => 
            MakeCallAsync<ToggleInputResponse>(new { inputName });

        public class GetInputVolumeResponse : ResponsesBase
        {
            public int InputVolumeMul { get; set; }
            public int InputVolumeDb { get; set; }
        }
        public Task<GetInputVolumeResponse> GetInputVolumeAsync(string inputName) => 
            MakeCallAsync<GetInputVolumeResponse>(new { inputName });

        public Task SetInputVolumeAsync(string inputName,
                                        int? inputVolumeMul = null,
                                        int? inputVolumeDb = null) =>
            MakeCallAsync(new
            {
                inputName,
                inputVolumeMul,
                inputVolumeDb
            });

        public class GetInputAudioBalanceResponse : ResponsesBase
        {
            public float InputAudioBalance { get; set; }
        }
        public Task<GetInputAudioBalanceResponse> GetInputAudioBalanceAsync(string inputName) => 
            MakeCallAsync<GetInputAudioBalanceResponse>(new { inputName });

        public Task SetInputAudioBalanceAsync(string inputName, float inputAudioBalance) => 
            MakeCallAsync(new { inputName, inputAudioBalance });

        public class GetInputAudioSyncOffsetResponse : ResponsesBase
        {
            public int InputAudioSyncOffset { get; set; }
        }
        public Task<GetInputAudioSyncOffsetResponse> GetInputAudioSyncOffsetAsync(string inputName) => 
            MakeCallAsync<GetInputAudioSyncOffsetResponse>(new { inputName });

        public Task SetInputAudioSyncOffsetAsync(string inputName, int inputAudioSyncOffset) => 
            MakeCallAsync(new { inputName, inputAudioSyncOffset });

        public class GetInputAudioMonitorTypeResponse : ResponsesBase
        {
            public MonitoringType MonitorType { get; set; }
        }
        public Task<GetInputAudioMonitorTypeResponse> GetInputAudioMonitorTypeAsync(string inputName) => 
            MakeCallAsync<GetInputAudioMonitorTypeResponse>(new { inputName });

        public Task SetInputAudioMonitorTypeAsync(string inputName, MonitoringType monitorType) => 
            MakeCallAsync(new { inputName, monitorType });

        public class GetInputAudioTracksResponse : ResponsesBase
        {
            public JObject InputAudioTracks { get; set; }
        }
        public Task<GetInputAudioTracksResponse> GetInputAudioTracksAsync(string inputName) => 
            MakeCallAsync<GetInputAudioTracksResponse>(new { inputName });

        public Task SetInputAudioTracksAsync(string inputName, object inputAudioTracks) => 
            MakeCallAsync(new { inputName, inputAudioTracks });

        public class GetInputPropertiesListPropertyItemsResponse : ResponsesBase
        {
            public JObject[] PropertyItems { get; set; }
        }
        public Task<GetInputPropertiesListPropertyItemsResponse> GetInputPropertiesListPropertyItemsAsync(string inputName, string propertyName) => 
            MakeCallAsync<GetInputPropertiesListPropertyItemsResponse>(new { inputName, propertyName });

        public Task PressInputPropertiesButtonAsync(string inputName, string propertyName) => 
            MakeCallAsync(new { inputName, propertyName });
    }
}

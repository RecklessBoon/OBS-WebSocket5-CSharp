using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class ConfigRequests : RequestsBase
    {
        public ConfigRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetPersistentDataResponse : ResponsesBase
        {
            public JObject SlotValue { get; set; }
        }
        public Task<GetPersistentDataResponse> GetPersistentDataAsync(WebSocketDataRealmType realm, string slotName) => 
            MakeCallAsync<GetPersistentDataResponse>(new { realm, slotName });

        public Task SetPersistentDataAsync(WebSocketDataRealmType realm, string slotName, object slotValue) => 
            MakeCallAsync(new { realm, slotName, slotValue });

        public class GetSceneCollectionListResponse : ResponsesBase
        {
            public string CurrentSceneCollectionName { get; set; }
            public string[] SceneCollections { get; set; }
        }
        public Task<GetSceneCollectionListResponse> GetSceneCollectionListAsync() => 
            MakeCallAsync<GetSceneCollectionListResponse>();

        public Task SetCurrentSceneCollectionAsync(string sceneCollectionName) => 
            MakeCallAsync(new { sceneCollectionName });

        public Task CreateSceneCollectionAsync(string sceneCollectionName) => 
            MakeCallAsync(new { sceneCollectionName });

        public class GetProfileListResponse : ResponsesBase
        {
            public string CurrentProfileName { get; set; }
            public string[] Profiles { get; set; }
        }
        public Task<GetProfileListResponse> GetProfileListAsync() => 
            MakeCallAsync<GetProfileListResponse>();

        public Task SetCurrentProfileAsync(string profileName) => 
            MakeCallAsync(new { profileName });

        public Task CreateProfileAsync(string profileName) => 
            MakeCallAsync(new { profileName });

        public Task RemoveProfileAsync(string profileName) => 
            MakeCallAsync(new { profileName });

        public class GetProfileParameterResponse : ResponsesBase
        {
            public string ParameterValue { get; set; }
            public string DefaultParameterValue { get; set; }
        }
        public Task<GetProfileParameterResponse> GetProfileParameterAsync(string parameterCategory, string parameterName) => 
            MakeCallAsync<GetProfileParameterResponse>(new { parameterCategory, parameterName });

        public Task SetProfileParameterAsync(string parameterCategory, string parameterName, string parameterValue) => 
            MakeCallAsync(new { parameterCategory, parameterName, parameterValue });

        public class GetVideoSettingsResponse : ResponsesBase
        {
            public int FpsNumerator { get; set; }
            public int FpsDenominator { get; set; }
            public int BaseWidth { get; set; }
            public int BaseHeight { get; set; }
            public int OutputWidth { get; set; }
            public int OutputHeight { get; set; }
        }
        public Task<GetVideoSettingsResponse> GetVideoSettingsAsync() => 
            MakeCallAsync<GetVideoSettingsResponse>();

        public Task SetVideoSettings(int? fpsNumerator = null, 
                                     int? fpsDenominator = null, 
                                     int? baseWidth = null, 
                                     int? baseHeight = null, 
                                     int? outputWidth = null, 
                                     int? outputHeight = null) => 
            MakeCallAsync(new
            {
                fpsNumerator,
                fpsDenominator,
                baseWidth,
                baseHeight,
                outputWidth,
                outputHeight
            });

        public class GetStreamServiceSettingsResponse : ResponsesBase
        {
            public string StreamServiceType { get; set; }
            public JObject StreamServiceSettings { get; set; }
        }
        public Task<GetStreamServiceSettingsResponse> GetStreamServiceSettingsAsync() => 
            MakeCallAsync<GetStreamServiceSettingsResponse>();

        public Task SetStreamServiceSettingsAsync(string streamServiceType, object streamServiceSettings) => 
            MakeCallAsync(new { streamServiceType, streamServiceSettings });

        public class GetRecordDirectoryResponse : ResponsesBase
        {
            public string RecordDirectory { get; set; }
        }
        public Task<GetRecordDirectoryResponse> GetRecordDirectoryAsync() => 
            MakeCallAsync<GetRecordDirectoryResponse>();
    }
}

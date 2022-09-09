using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class SceneItemsRequests : RequestsBase
    {
        public SceneItemsRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetSceneItemListResponse : ResponsesBase
        {
            public JObject[] SceneItems { get; set; }
        }
        public Task<GetSceneItemListResponse> GetSceneItemListAsync(string sceneName) => 
            MakeCallAsync<GetSceneItemListResponse>(new { sceneName });

        public class GetGroupSceneItemListResponse : ResponsesBase
        {
            public JObject[] SceneItems { get; set; }
        }
        public Task<GetGroupSceneItemListResponse> GetGroupSceneItemListAsync(string sceneName) => 
            MakeCallAsync<GetGroupSceneItemListResponse>(new { sceneName });

        public class GetSceneItemIdResponse : ResponsesBase
        {
            public int SceneItemId { get; set; }
        }
        public Task<GetSceneItemIdResponse> GetSceneItemIdAsync(string sceneName,
                                                 string sourceName,
                                                 int? searchOffset = null) =>
            MakeCallAsync<GetSceneItemIdResponse>(new
            {
                sceneName,
                sourceName,
                searchOffset
            });

        public class CreateSceneItemResponse : ResponsesBase
        {
            public int SceneItemId { get; set; }
        }
        public Task<CreateSceneItemResponse> CreateSceneItemAsync(string sceneName,
                                             string sourceName,
                                             bool? sceneItemEnabled = null) =>
            MakeCallAsync<CreateSceneItemResponse>(new
            {
                sceneName,
                sourceName,
                sceneItemEnabled
            });

        public Task RemoveSceneItemAsync(string sceneName, string sceneItemId) => 
            MakeCallAsync(new { sceneName, sceneItemId });

        public class DuplicateSceneItemResponse : ResponsesBase
        {
            public int SceneItemId { get; set; }
        }
        public Task<DuplicateSceneItemResponse> DuplicateSceneItemAsync(string sceneName,
                                                     string sceneItemId,
                                                     string destinationSceneName = null) =>
            MakeCallAsync<DuplicateSceneItemResponse>(new
            {
                sceneName,
                sceneItemId,
                destinationSceneName
            });

        public class GetSceneItemTransformResponse : ResponsesBase
        {
            public JObject SceneItemTransform { get; set; }
        }
        public Task<GetSceneItemTransformResponse> GetSceneItemTransformAsync(string sceneName, string sceneItemId) => 
            MakeCallAsync<GetSceneItemTransformResponse>(new { sceneName, sceneItemId });

        public Task SetSceneItemTransformAsync(string sceneName,
                                               string sceneItemId,
                                               object sceneItemTransform) =>
            MakeCallAsync(new
            {
                sceneName,
                sceneItemId,
                sceneItemTransform
            });

        public class GetSceneItemEnabledResponse : ResponsesBase
        {
            public bool SceneItemEnabled { get; set; }
        }
        public Task<GetSceneItemEnabledResponse> GetSceneItemEnabledAsync(string sceneName, int sceneItemId) => 
            MakeCallAsync<GetSceneItemEnabledResponse>(new { sceneName, sceneItemId });

        public Task SetSceneItemEnabledAsync(string sceneName, int sceneItemId, bool sceneItemEnabled) => 
            MakeCallAsync(new { sceneName, sceneItemId, sceneItemEnabled });

        public class GetSceneItemLockedResponse : ResponsesBase
        {
            public bool SceneItemLocked { get; set; }
        }
        public Task<GetSceneItemLockedResponse> GetSceneItemLockedAsync(string sceneName, int sceneItemId) => 
            MakeCallAsync<GetSceneItemLockedResponse>(new { sceneName, sceneItemId });

        public Task SetSceneItemLockedAsync(string sceneName, int sceneItemId, bool sceneItemLocked) => 
            MakeCallAsync(new { sceneName, sceneItemId, sceneItemLocked });

        public class GetSceneItemIndexResponse : ResponsesBase
        {
            public int SceneItemIndex { get; set; }
        }
        public Task<GetSceneItemIndexResponse> GetSceneItemIndexAsync(string sceneName, int sceneItemId) => 
            MakeCallAsync<GetSceneItemIndexResponse>(new { sceneName, sceneItemId });

        public Task SetSceneItemIndexAsync(string sceneName, int sceneItemId, int sceneItemIndex) => 
            MakeCallAsync(new { sceneName, sceneItemId, sceneItemIndex });

        public class GetSceneItemBlendModeResponse : ResponsesBase
        {
            public BlendModeType SceneItemBlendMode { get; set; }
        }
        public Task<GetSceneItemBlendModeResponse> GetSceneItemBlendModeAsync(string sceneName, int sceneItemId) => 
            MakeCallAsync<GetSceneItemBlendModeResponse>(new { sceneName, sceneItemId });

        public Task SetSceneItemBlendModeAsync(string sceneName,
                                               int sceneItemId,
                                               BlendModeType sceneItemBlendMode) =>
            MakeCallAsync(new
            {
                sceneName,
                sceneItemId,
                sceneItemBlendMode
            });
    }
}

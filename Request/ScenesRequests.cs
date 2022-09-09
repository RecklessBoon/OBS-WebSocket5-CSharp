using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class ScenesRequests : RequestsBase
    {
        public ScenesRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetSceneListResponse : ResponsesBase
        {
            public string CurrentProgramSceneName { get; set; }
            public string CurrentPreviewSceneName { get; set; }
            public JObject[] Scenes { get; set; }
        }
        public Task<GetSceneListResponse> GetSceneListAsync() => 
            MakeCallAsync<GetSceneListResponse>();

        public class GetGroupListResponse : ResponsesBase
        {
            public string[] Groups { get; set; }
        }
        public Task<GetGroupListResponse> GetGroupListAsync() => 
            MakeCallAsync<GetGroupListResponse>();

        public class GetCurrentProgramSceneResponse : ResponsesBase
        {
            public string CurrentProgramSceneName { get; set; }
        }
        public Task<GetCurrentProgramSceneResponse> GetCurrentProgramSceneAsync() => 
            MakeCallAsync<GetCurrentProgramSceneResponse>();

        public Task SetCurrentProgramSceneAsync(string sceneName) => 
            MakeCallAsync(new { sceneName });

        public class GetCurrentPreviewSceneResponse : ResponsesBase
        {
            public string CurrentPreviewSceneName { get; set; }
        }
        public Task<GetCurrentPreviewSceneResponse> GetCurrentPreviewSceneAsync() => 
            MakeCallAsync<GetCurrentPreviewSceneResponse>();

        public Task SetCurrentPreviewSceneAsync(string sceneName) => 
            MakeCallAsync(new { sceneName });

        public Task CreateSceneAsync(string sceneName) => 
            MakeCallAsync(new { sceneName });

        public Task RemoveSceneAsync(string sceneName) => 
            MakeCallAsync(new { sceneName });

        public Task SetSceneNameAsync(string sceneName, string newSceneName) => 
            MakeCallAsync(new { sceneName, newSceneName });

        public class GetSceneSceneTransitionOverrideResponse : ResponsesBase
        {
            public string TransitionName { get; set; }
            public int? TransitionDuration { get; set; }
        }
        public Task<GetSceneSceneTransitionOverrideResponse> GetSceneSceneTransitionOverrideAsync(string sceneName) => 
            MakeCallAsync<GetSceneSceneTransitionOverrideResponse>(new { sceneName });

        public Task SetSceneSceneTransitionOverrideAsync(string sceneName, 
                                                         string transitionName = null, 
                                                         int? transitionDuration = null) => 
            MakeCallAsync(new
            {
                sceneName,
                transitionName,
                transitionDuration
            });
    }
}

using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class TransitionsRequests : RequestsBase
    {
        public TransitionsRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetTransitionKindListResponse : ResponsesBase
        {
            public string[] TransitionKinds { get; set; }
        }
        public Task<GetTransitionKindListResponse> GetTransitionKindListAsync() => 
            MakeCallAsync<GetTransitionKindListResponse>();

        public class GetSceneTransitionListResponse : ResponsesBase
        {
            public string CurrentSceneTransitionName { get; set; }
            public string CurrentSceneTransitionKind { get; set; }
            public JObject[] Transitions { get; set; }
        }
        public Task<GetSceneTransitionListResponse> GetSceneTransitionListAsync() => 
            MakeCallAsync<GetSceneTransitionListResponse>();

        public class GetCurrentSceneTransitionResponse : ResponsesBase
        {
            public string TransitionName { get; set; }
            public string TransitionKind { get; set; }
            public bool TransitionFixed { get; set; }
            public int? TransitionDuration { get; set; }
            public bool TransitionConfigurable { get; set; }
            public JObject TransitionSettings { get; set; }
        }
        public Task<GetCurrentSceneTransitionResponse> GetCurrentSceneTransitionAsync() => 
            MakeCallAsync<GetCurrentSceneTransitionResponse>();

        public Task SetCurrentSceneTransitionAsync(string transitionName) => 
            MakeCallAsync(new { transitionName });

        public Task SetCurrentSceneTransitionDurationAsync(int transitionDuration) => 
            MakeCallAsync(new { transitionDuration });

        public Task SetCurrentSceneTransitionSettingsAsync(object transitionSettings, bool? overlay = null) => 
            MakeCallAsync(new { transitionSettings, overlay });

        public class GetCurrentSceneTransitionCursorResponse : ResponsesBase
        {
            public float TransitionCursor { get; set; }
        }
        public Task<GetCurrentSceneTransitionCursorResponse> GetCurrentSceneTransitionCursorAsync() => 
            MakeCallAsync<GetCurrentSceneTransitionCursorResponse>();

        public Task TriggerStudioModeTransitionAsync() => 
            MakeCallAsync();

        public Task SetTBarPositionAsync(float position, bool? release) => 
            MakeCallAsync(new { position, release });
    }
}

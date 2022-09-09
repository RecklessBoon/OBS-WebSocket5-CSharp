using Newtonsoft.Json.Linq;
using OBSWebSocket5.Frames;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class ScenesEvents : EventsBase
    {
        public ScenesEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}       

        public class SceneCreatedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public bool IsGroup { get; set; }
        }
        public event EventHandler<SceneCreatedEventArgs> SceneCreated { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneRemovedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public bool IsGroup { get; set; }
        }
        public event EventHandler<SceneRemovedEventArgs> SceneRemoved { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneNameChangedEventArgs : EventArgs
        {
            public string OldSceneName { get; set; }
            public string SceneName { get; set; }
        }
        public event EventHandler<SceneNameChangedEventArgs> SceneNameChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }        

        public class CurrentProgramSceneChangedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
        }
        public event EventHandler<CurrentProgramSceneChangedEventArgs> CurrentProgramSceneChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class CurrentPreviewSceneChangedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
        }
        public event EventHandler<CurrentPreviewSceneChangedEventArgs> CurrentPreviewSceneChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
        
        public class SceneListChangedEventArgs : EventArgs
        {
            public JObject[] Scenes { get; set; }
        }
        public event EventHandler<SceneListChangedEventArgs> SceneListChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

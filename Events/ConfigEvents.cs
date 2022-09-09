using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class ConfigEvents : EventsBase
    {
        public ConfigEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class SceneCollectionChangeEventArgs : EventArgs
        {
            public string SceneCollectionName { get; set; }
        }
        public event EventHandler<SceneCollectionChangeEventArgs> CurrentSceneCollectionChanging { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
        
        public event EventHandler<SceneCollectionChangeEventArgs> CurrentSceneCollectionChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneCollectionListChangeEventArgs : EventArgs
        {
            public string[] SceneCollections { get; set; }
        }
        public event EventHandler<SceneCollectionListChangeEventArgs> SceneCollectionListChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class ProfileChangeEventArgs : EventArgs
        {
            public string ProfileName { get; set; }
        }
        public event EventHandler<ProfileChangeEventArgs> CurrentProfileChanging { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public event EventHandler<ProfileChangeEventArgs> CurrentProfileChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class ProfileListChangeEventArgs : EventArgs
        {
            public string[] Profiles { get; set; }
        }
        public event EventHandler<ProfileListChangeEventArgs> ProfileListChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

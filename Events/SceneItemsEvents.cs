using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class SceneItemsEvents : EventsBase
    {
        public SceneItemsEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class SceneItemCreatedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public string SourceName { get; set; }
            public int SceneItemId { get; set; }
            public int SceneItemIndex { get; set; }
        }
        public event EventHandler<SceneItemCreatedEventArgs> SceneItemCreated { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneItemRemovedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public string SourceName { get; set; }
            public int SceneItemId { get; set; }
        }
        public event EventHandler<SceneItemRemovedEventArgs> SceneItemRemoved { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneItemListReindexedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public JObject[] SceneItems { get; set; }
        }
        public event EventHandler<SceneItemListReindexedEventArgs> SceneItemListReindexed { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneItemEnableStateChangedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public int SceneItemId { get; set; }
            public bool SceneItemEnabled { get; set; }
        }
        public event EventHandler<SceneItemEnableStateChangedEventArgs> SceneItemEnableStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneItemLockStateChangedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public int SceneItemId { get; set; }
            public bool SceneItemLocked { get; set; }
        }
        public event EventHandler<SceneItemLockStateChangedEventArgs> SceneItemLockStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneItemSelectedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public int SceneItemId { get; set; }
        }
        public event EventHandler<SceneItemSelectedEventArgs> SceneItemSelected { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneItemTransformChangedEventArgs : EventArgs
        {
            public string SceneName { get; set; }
            public int SceneItemId { get; set; }
            public JObject SceneItemTransform { get; set; }
        }
        public event EventHandler<SceneItemTransformChangedEventArgs> SceneItemTransformChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class TransitionsEvents : EventsBase
    {
        public TransitionsEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class CurrentSceneTransitionChangedEventArgs : EventArgs
        {
            public string TransitionName { get; set; }
        }
        public event EventHandler<CurrentSceneTransitionChangedEventArgs> CurrentSceneTransitionChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class CurrentSceneTransitionDurationChangedEventArgs : EventArgs
        {
            public int TransitionDuration { get; set; }
        }
        public event EventHandler<CurrentSceneTransitionDurationChangedEventArgs> CurrentSceneTransitionDurationChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneTransitionStartedEventArgs : EventArgs
        {
            public string TransitionName { get; set; }
        }
        public event EventHandler<SceneTransitionStartedEventArgs> SceneTransitionStarted { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneTransitionEndedEventArgs : EventArgs
        {
            public string TransitionName { get; set; }
        }
        public event EventHandler<SceneTransitionEndedEventArgs> SceneTransitionEnded { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SceneTransitionVideoEndedEventArgs : EventArgs
        {
            public string TransitionName { get; set; }
        }
        public event EventHandler<SceneTransitionVideoEndedEventArgs> SceneTransitionVideoEnded { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class MediaInputsEvents : EventsBase
    {
        public MediaInputsEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class MediaInputPlaybackStartedEventArgs : EventArgs
        {
            public string InputName { get; set; }
        }
        public event EventHandler<MediaInputPlaybackStartedEventArgs> MediaInputPlaybackStarted { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class MediaInputPlaybackEndedEventArgs : EventArgs
        {
            public string InputName { get; set; }
        }
        public event EventHandler<MediaInputPlaybackEndedEventArgs> MediaInputPlaybackEnded { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class MediaInputActionTriggeredEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public string MediaAction { get; set; }
        }
        public event EventHandler<MediaInputActionTriggeredEventArgs> MediaInputActionTriggered { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class UiEvents : EventsBase
    {
        public UiEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class StudioModeStateChangedEventArgs : EventArgs
        {
            public bool StudioModeEnabled { get; set; }
        }
        public event EventHandler<StudioModeStateChangedEventArgs> StudioModeStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

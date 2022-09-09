using Newtonsoft.Json.Linq;
using OBSWebSocket5.Frames;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class GeneralEvents : EventsBase
    {
        public GeneralEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public event EventHandler ExitStarted { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class VendorEventEventArgs : EventArgs
        {
            public string VendorName { get; set; }
            public string EventType { get; set; }
            public JObject EventData { get; set; }
        }
        public event EventHandler<VendorEventEventArgs> VendorEvent { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

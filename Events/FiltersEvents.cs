using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class FiltersEvents : EventsBase
    {
        public FiltersEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class SourceFilterListReindexedEventArgs : EventArgs
        {
            public string SourceName { get; set; }
            public JObject[] Filters { get; set; }
        }
        public event EventHandler<SourceFilterListReindexedEventArgs> SourceFilterListReindexed { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SourceFilterCreatedEventArgs : EventArgs
        {
            public string SourceName { get; set; }
            public string FilterName { get; set; }
            public string FilterKind { get; set; }
            public int FilterIndex { get; set; }
            public JObject FilterSettings { get; set; }
            public JObject DefaultFilterSettings { get; set; }
        }
        public event EventHandler<SourceFilterCreatedEventArgs> SourceFilterCreated { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SourceFilterRemovedEventArgs : EventArgs
        {
            public string SourceName { get; set; }
            public string FilterName { get; set; }
        }
        public event EventHandler<SourceFilterRemovedEventArgs> SourceFilterRemoved { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SourceFilterNameChangedEventArgs : EventArgs
        {
            public string SourceName { get; set; }
            public string OldFilterName { get; set; }
            public string FilterName { get; set; }
        }
        public event EventHandler<SourceFilterNameChangedEventArgs> SourceFilterNameChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class SourceFilterEnableStateChangedEventArgs : EventArgs
        {
            public string SourceName { get; set; }
            public string FilterName { get; set; }
            public bool FilterEnabled { get; set; }
        }
        public event EventHandler<SourceFilterEnableStateChangedEventArgs> SourceFilterEnableStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class OutputsEvents : EventsBase
    {
        public OutputsEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class StreamStateChangedEventArgs : EventArgs
        {
            public bool OutputActive { get; set; }
            public string OutputState { get; set; }
        }
        public event EventHandler<StreamStateChangedEventArgs> StreamStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class RecordStateChangedEventArgs : EventArgs
        {
            public bool OutputActive { get; set; }
            public string OutputState { get; set; }
            public string OutputPath { get; set; }
        }
        public event EventHandler<RecordStateChangedEventArgs> RecordStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class ReplayBufferStateChangedEventArgs : EventArgs
        {
            public bool OutputActive { get; set; }
            public string OutputState { get; set; }
        }
        public event EventHandler<ReplayBufferStateChangedEventArgs> ReplayBufferStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class VirtualcamStateChangedEventArgs : EventArgs
        {
            public bool OutputActive { get; set; }
            public string OutputState { get; set; }
        }
        public event EventHandler<VirtualcamStateChangedEventArgs> VirtualcamStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class ReplayBufferSavedEventArgs : EventArgs
        {
            public string SavedReplayPath { get; set; }
        }
        public event EventHandler<ReplayBufferSavedEventArgs> ReplayBufferSaved { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

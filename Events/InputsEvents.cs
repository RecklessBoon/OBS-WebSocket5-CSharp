using Newtonsoft.Json.Linq;
using OBSWebSocket5.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5.Events
{
    public class InputsEvents : EventsBase
    {
        public InputsEvents(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher) {}

        public class InputCreatedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public string InputKind { get; set; }
            public string UnversionedInputKind { get; set; }
            public JObject InputSettings { get; set; }
            public JObject DefaultInputSettings { get; set; }
        }
        public event EventHandler<InputCreatedEventArgs> InputCreated { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputRemovedEventArgs : EventArgs
        {
            public string InputName { get; set; }
        }
        public event EventHandler<InputRemovedEventArgs> InputRemoved { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputNameChangedEventArgs : EventArgs
        {
            public string OldInputName { get; set; }
            public string InputName { get; set; }
        }
        public event EventHandler<InputNameChangedEventArgs> InputNameChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputActiveStateChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public bool VideoActive { get; set; }
        }
        public event EventHandler<InputActiveStateChangedEventArgs> InputActiveStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputShowStateChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public bool VideoShowing { get; set; }
        }
        public event EventHandler<InputShowStateChangedEventArgs> InputShowStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputMuteStateChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public bool InputMuted { get; set; }
        }
        public event EventHandler<InputMuteStateChangedEventArgs> InputMuteStateChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputVolumeChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public int InputVolumeMul { get; set; }
            public int InputVolumeDb { get; set; }
        }
        public event EventHandler<InputVolumeChangedEventArgs> InputVolumeChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputAudioBalanceChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public int InputAudioBalance { get; set; }
        }
        public event EventHandler<InputAudioBalanceChangedEventArgs> InputAudioBalanceChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputAudioSyncOffsetChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public int InputAudioSyncOffset { get; set; }
        }
        public event EventHandler<InputAudioSyncOffsetChangedEventArgs> InputAudioSyncOffsetChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputAudioTracksChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public JObject InputAudioTracks { get; set; }
        }
        public event EventHandler<InputAudioTracksChangedEventArgs> InputAudioTracksChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputAudioMonitorTypeChangedEventArgs : EventArgs
        {
            public string InputName { get; set; }
            public MonitoringType MonitorType { get; set; }
        }
        public event EventHandler<InputAudioMonitorTypeChangedEventArgs> InputAudioMonitorTypeChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }

        public class InputVolumeMetersEventArgs : EventArgs
        {
            public JObject[] Inputs { get; set; }
        }
        public event EventHandler<InputVolumeMetersEventArgs> InputVolumeMetersChanged { add => AddSubscriber(value); remove => RemoveSubscriber(value); }
    }
}

using OBSWebSocket5.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Net;
using System.Text;
using static OBSWebSocket5.OBSWebSocket;
using System.Threading;

namespace OBSWebSocket5
{
    public partial class OBSWebSocket
    {
        protected GeneralRequests _GeneralRequests;
        public GeneralRequests GeneralRequests => _GeneralRequests;

        protected ConfigRequests _ConfigReqeusts;
        public ConfigRequests ConfigRequests => _ConfigReqeusts;

        protected SourcesRequests _SourcesRequests;
        public SourcesRequests SourcesRequests => _SourcesRequests;

        protected ScenesRequests _ScenesRequests;
        public ScenesRequests ScenesRequests => _ScenesRequests;

        protected InputsRequests _InputsRequests;
        public InputsRequests InputsRequests => _InputsRequests;

        protected TransitionsRequests _TransitionsRequests;
        public TransitionsRequests TransitionsRequests => _TransitionsRequests;

        protected FiltersRequests _FiltersRequests;
        public FiltersRequests FiltersRequests => _FiltersRequests;

        protected SceneItemsRequests _SceneItemsRequests;
        public SceneItemsRequests SceneItemsRequests => _SceneItemsRequests;

        protected OutputsRequests _OutputsRequests;
        public OutputsRequests OutputsRequests => _OutputsRequests;

        protected StreamRequests _StreamRequests;
        public StreamRequests StreamRequests => _StreamRequests;

        protected RecordRequests _RecordRequests;
        public RecordRequests RecordRequests => _RecordRequests;

        protected MediaInputsRequests _MediaInputsRequests;
        public MediaInputsRequests MediaInputsRequests => _MediaInputsRequests;

        protected UiRequests _UiRequests;
        public UiRequests UiRequests => _UiRequests;

        public void InitRequestServices()
        {
            _GeneralRequests = new GeneralRequests(Dispatcher);
            _ConfigReqeusts = new ConfigRequests(Dispatcher);
            _SourcesRequests = new SourcesRequests(Dispatcher);
            _ScenesRequests = new ScenesRequests(Dispatcher);
            _InputsRequests = new InputsRequests(Dispatcher);
            _TransitionsRequests = new TransitionsRequests(Dispatcher);
            _FiltersRequests = new FiltersRequests(Dispatcher);
            _SceneItemsRequests = new SceneItemsRequests(Dispatcher);
            _OutputsRequests = new OutputsRequests(Dispatcher);
            _StreamRequests = new StreamRequests(Dispatcher);
            _RecordRequests = new RecordRequests(Dispatcher);
            _MediaInputsRequests = new MediaInputsRequests(Dispatcher);
            _UiRequests = new UiRequests(Dispatcher);
        }
    }
}

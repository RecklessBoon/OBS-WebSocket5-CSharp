using OBSWebSocket5.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace OBSWebSocket5
{
    public partial class OBSWebSocket
    {
        protected GeneralEvents _GeneralEvents;
        public GeneralEvents GeneralEvents => _GeneralEvents;

        protected ConfigEvents _ConfigEvents;
        public ConfigEvents ConfigEvents => _ConfigEvents;

        protected ScenesEvents _ScenesEvents;
        public ScenesEvents ScenesEvents => _ScenesEvents;

        protected InputsEvents _InputsEvents;
        public InputsEvents InputsEvents => _InputsEvents;

        protected TransitionsEvents _TransitionsEvents;
        public TransitionsEvents TransitionsEvents => _TransitionsEvents;

        protected FiltersEvents _FiltersEvents;
        public FiltersEvents FiltersEvents => _FiltersEvents;

        protected SceneItemsEvents _SceneItemsEvents;
        public SceneItemsEvents SceneItemsEvents => _SceneItemsEvents;

        protected OutputsEvents _OutputsEvents;
        public OutputsEvents OutputsEvents => _OutputsEvents;

        protected MediaInputsEvents _MediaInputsEvents;
        public MediaInputsEvents MediaInputsEvents => _MediaInputsEvents;

        protected UiEvents _UiEvents;
        public UiEvents UiEvents => _UiEvents;

        protected void InitEventServices()
        {
            _GeneralEvents = new GeneralEvents(_Dispatcher);
            _ConfigEvents = new ConfigEvents(_Dispatcher);
            _ScenesEvents = new ScenesEvents(_Dispatcher);
            _InputsEvents = new InputsEvents(_Dispatcher);
            _TransitionsEvents = new TransitionsEvents(_Dispatcher);
            _FiltersEvents = new FiltersEvents(_Dispatcher);
            _SceneItemsEvents = new SceneItemsEvents(_Dispatcher);
            _OutputsEvents = new OutputsEvents(_Dispatcher);
            _MediaInputsEvents = new MediaInputsEvents(_Dispatcher);
            _UiEvents = new UiEvents(_Dispatcher);
        }
    }
}

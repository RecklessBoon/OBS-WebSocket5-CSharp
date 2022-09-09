using OBSWebSocket5.Frames;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static OBSWebSocket5.OBSWebSocket;

namespace OBSWebSocket5.Events
{
    public class EventsBase
    {
        public MessageDispatcher _Dispatcher;

        public EventsBase(MessageDispatcher dispatcher)
        {
            _Dispatcher = dispatcher;
        }

        protected void AddSubscriber(EventHandler handler, [CallerMemberName] string propertyName = "")
        {
            _Dispatcher.Subscribe(propertyName, handler);
        }

        protected void RemoveSubscriber(EventHandler handler, [CallerMemberName] string propertyName = "")
        {
            _Dispatcher.Unsubscribe(propertyName);
        }

        protected void AddSubscriber<T>(EventHandler<T> handler, [CallerMemberName] string propertyName = "")
        {
            _Dispatcher.Subscribe<T>(propertyName, handler);
        }

        protected void RemoveSubscriber<T>(EventHandler<T> handler, [CallerMemberName] string propertyName = "")
        {
            _Dispatcher.Unsubscribe(propertyName);
        }
    }
}

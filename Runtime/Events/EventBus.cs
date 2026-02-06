using System;
using System.Collections.Generic;
using System.Linq;
using albatroneer.CoreArchitecture;
using UnityEngine;

namespace albatroneer.CoreArchitecture.Events
{
    public class EventBus : AbstractMonoBehaviour, IEventer
    {
        private struct Eventer
        {
            public int Priority;
            public Delegate Delegates;
        }

        private struct EventerGuid
        {
            public int Priority;
            public Delegate Delegates;
            public Guid Guid;
        }

        private readonly Dictionary<Type, List<Eventer>> _listeners = new();
        private readonly Dictionary<Type, List<EventerGuid>> _listenerGUIDs = new();
        private readonly Dictionary<Type, List<Eventer>> _globalListeners = new();

        public void Subscribe<T>(Action<T> callback, int priority = 0) where T : struct
        {
            var type = typeof(T);

            if (!_listeners.ContainsKey(type))
            {
                _listeners[type] = new List<Eventer>();
            }

            _listeners[type].Add(new Eventer() { Priority = priority, Delegates = callback });
            _listeners[type].Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }

        public void Subscribe<T>(Action<T> callback, Guid guid, int priority = 0) where T : struct
        {
            var type = typeof(T);

            if (!_listenerGUIDs.ContainsKey(type))
            {
                _listenerGUIDs[type] = new List<EventerGuid>();
            }

            _listenerGUIDs[type].Add(new EventerGuid() { Priority = priority, Delegates = callback, Guid = guid });
            _listenerGUIDs[type].Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }

        /// <summary>
        /// Подписка на все события данного типа, независимо от Guid
        /// </summary>
        public void SubscribeGlobal<T>(Action<T> callback, int priority = 0) where T : struct
        {
            var type = typeof(T);

            if (!_globalListeners.ContainsKey(type))
            {
                _globalListeners[type] = new List<Eventer>();
            }

            _globalListeners[type].Add(new Eventer() { Priority = priority, Delegates = callback });
            _globalListeners[type].Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }

        public void Unsubscribe<T>(Action<T> callback) where T : struct
        {
            var type = typeof(T);

            if (_listeners.TryGetValue(type, out var eventers))
            {
                int index = eventers.FindIndex(e => e.Delegates is Action<T> existing && existing == callback);
                if (index != -1)
                {
                    eventers.RemoveAt(index);
                    if (eventers.Count == 0)
                        _listeners.Remove(type);
                }
            }

            if (_globalListeners.TryGetValue(type, out var globals))
            {
                int index = globals.FindIndex(e => e.Delegates is Action<T> existing && existing == callback);
                if (index != -1)
                {
                    globals.RemoveAt(index);
                    if (globals.Count == 0)
                        _globalListeners.Remove(type);
                }
            }
        }

        public void Unsubscribe<T>(Action<T> callback, Guid guid) where T : struct
        {
            var type = typeof(T);

            if (_listenerGUIDs.TryGetValue(type, out var eventers))
            {
                int index = eventers.FindIndex(e => e.Delegates is Action<T> existing && existing == callback && guid == e.Guid);
                if (index != -1)
                {
                    eventers.RemoveAt(index);
                    if (eventers.Count == 0)
                        _listenerGUIDs.Remove(type);
                }
            }
        }

        public void Publish<T>(T eventData) where T : struct
        {
            var type = typeof(T);

            if (_listeners.TryGetValue(type, out var eventers))
            {
                foreach (var eventer in eventers.ToList())
                {
                    ((Action<T>)eventer.Delegates)?.Invoke(eventData);
                }
            }

            if (_globalListeners.TryGetValue(type, out var globals))
            {
                foreach (var eventer in globals.ToList())
                {
                    ((Action<T>)eventer.Delegates)?.Invoke(eventData);
                }
            }
        }

        public void Publish<T>(T eventData, Guid guid) where T : struct
        {
            var type = typeof(T);

            if (_listenerGUIDs.TryGetValue(type, out var eventers))
            {
                foreach (var eventer in eventers.ToList())
                {
                    if (eventer.Guid == guid)
                    {
                        ((Action<T>)eventer.Delegates)?.Invoke(eventData);
                    }
                }
            }

            if (_globalListeners.TryGetValue(type, out var globals))
            {
                foreach (var eventer in globals.ToList())
                {
                    ((Action<T>)eventer.Delegates)?.Invoke(eventData);
                }
            }
        }

        public void UnsubscribeAllGuid(Guid guid)
        {
            foreach (var type in _listenerGUIDs.Keys.ToList())
            {
                _listenerGUIDs[type].RemoveAll(e => e.Guid == guid);
                if (_listenerGUIDs[type].Count == 0)
                    _listenerGUIDs.Remove(type);
            }
        }

        protected override void Init() { }
    }
}

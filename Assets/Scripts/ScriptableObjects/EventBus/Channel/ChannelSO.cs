using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.EventBus.Channel
{
    [CreateAssetMenu(fileName = "NewChannel", menuName = "EventBus/NewChannel")]
    public class ChannelSO : BaseSO
    {
        private readonly Dictionary<Type, List<Action<object>>> _subscribers =
            new Dictionary<Type, List<Action<object>>>();

        public void Subscribe<T>(Action<T> subscriber)
        {
            var type = typeof(T);
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers[type] = new List<Action<object>>();
            }
            _subscribers[type].Add(e => subscriber((T)e));
        }

        public void Publish<T>(T eventMessage)
        {
            var type = typeof(T);
            if (_subscribers.ContainsKey(type))
            {
                foreach (var subscriber in _subscribers[type])
                {
                    subscriber.Invoke(eventMessage); // or subscriber(eventMessage);
                }
            }
        }

        public void Unsubscribe<T>(Action<T> subscriber)
        {
            var type = typeof(T);
            if (_subscribers.ContainsKey(type))
            {
                _subscribers[type].RemoveAll(s => s.Equals(subscriber));
                if (_subscribers[type].Count == 0)
                {
                    _subscribers.Remove(type);
                }
            }
        }
        
        
    }
}
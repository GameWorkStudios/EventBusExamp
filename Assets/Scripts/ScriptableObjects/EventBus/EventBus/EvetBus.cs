using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.EventBus.EventBus
{
    
    [CreateAssetMenu(fileName = "NewEventBus", menuName = "EventBus/EventBus")]
    public class EvetBus : BaseSO
    {
        private readonly Dictionary<string, Dictionary<System.Type, List<System.Action<object>>>> _channels 
            = new Dictionary<string, Dictionary<System.Type, List<System.Action<object>>>>();

        public void Subscribe<T>(string channel, System.Action<T> subscriber)
        {
            if (!_channels.ContainsKey(channel))
            {
                _channels[channel] = new Dictionary<System.Type, List<System.Action<object>>>();
            }

            var type = typeof(T);
            if (!_channels[channel].ContainsKey(type))
            {
                _channels[channel][type] = new List<System.Action<object>>();
            }

            _channels[channel][type].Add(e => subscriber((T)e));
        }

        public void Publish<T>(string channel, T eventMessage)
        {
            if (_channels.ContainsKey(channel))
            {
                var type = typeof(T);
                if (_channels[channel].ContainsKey(type))
                {
                    foreach (var subscriber in _channels[channel][type])
                    {
                        subscriber(eventMessage);
                    }
                }
            }
        }

        public void Unsubscribe<T>(string channel, System.Action<T> subscriber)
        {
            if (_channels.ContainsKey(channel))
            {
                var type = typeof(T);
                if (_channels[channel].ContainsKey(type))
                {
                    _channels[channel][type].RemoveAll(s => s.Equals(subscriber));
                    if (_channels[channel][type].Count == 0)
                    {
                        _channels[channel].Remove(type);
                    }
                }
                if (_channels[channel].Count == 0)
                {
                    _channels.Remove(channel);
                }
            }
        }
        
    }
}
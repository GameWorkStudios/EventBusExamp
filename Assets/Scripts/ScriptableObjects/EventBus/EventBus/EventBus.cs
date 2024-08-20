using System;
using ScriptableObjects.EventBus.Channel;
using UnityEngine;

namespace ScriptableObjects.EventBus.EventBus
{
    
    public class EventBus : MonoBehaviour
    {
        /// <summary>
        /// Different approach for singleton.
        /// </summary>
        #region Singleton
        public static EventBus Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        #endregion Singleton

        public void Subscribe<T>(ChannelSO channel, Action<T> subscriber)
        {
            channel.Subscribe(subscriber);
        }

        public void Publish<T>(ChannelSO channel, T eventMessage)
        {
            channel.Publish(eventMessage);
        }

        public void Unsubscribe<T>(ChannelSO channel, Action<T> subscriber)
        {
            channel.Unsubscribe(subscriber);
        }
        
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.EventBus.Channel;
using ScriptableObjects.EventBus.EventBus;
using ScriptableObjects.EventBus.Events;
using UnityEngine;

public class EventListener : MonoBehaviour
{

    [SerializeField] private ChannelSO inputChannel;
    
    private void OnEnable()
    {
        EventBus.Instance.Subscribe<KeyboardEvent>(inputChannel, OnKeyboardEvent);
        EventBus.Instance.Subscribe<MouseEvent>(inputChannel, OnMouseEvent);
    }

    private void OnDisable()
    {
        EventBus.Instance.Unsubscribe<KeyboardEvent>(inputChannel, OnKeyboardEvent);
        EventBus.Instance.Unsubscribe<MouseEvent>(inputChannel, OnMouseEvent);
    }

    private void OnKeyboardEvent(KeyboardEvent eventData)
    {
        Debug.Log("Keyboard Event Received: " + eventData.Key);
    }

    private void OnMouseEvent(MouseEvent eventData)
    {
        Debug.Log($"Mouse Event Received: Button {eventData.Button} at ({eventData.X}, {eventData.Y})");
    }
}

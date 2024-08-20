using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.EventBus.EventBus;
using ScriptableObjects.EventBus.Events;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    [SerializeField] private EvetBus eventBus;
    
    private void OnEnable()
    {
        eventBus.Subscribe<KeyboardEvent>("InputChannel", OnKeyboardEvent);
        eventBus.Subscribe<MouseEvent>("InputChannel", OnMouseEvent);        
    }

    private void OnDisable()
    {
        eventBus.Unsubscribe<KeyboardEvent>("InputChannel", OnKeyboardEvent);
        eventBus.Unsubscribe<MouseEvent>("InputChannel", OnMouseEvent);
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

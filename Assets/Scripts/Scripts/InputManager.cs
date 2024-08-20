using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.EventBus.Channel;
using Unity.VisualScripting;
using UnityEngine;
using ScriptableObjects.EventBus.EventBus;
using ScriptableObjects.EventBus.Events;
using EventBus = ScriptableObjects.EventBus.EventBus.EventBus;

public class InputManager : MonoBehaviour
{

    [SerializeField] private ChannelSO inputChannel;
    [SerializeField] private KeyboardEvent _keyboardEvent;
    [SerializeField] private MouseEvent _mouseEvent;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _keyboardEvent.Key = "Space";
            EventBus.Instance.Publish(inputChannel, _keyboardEvent);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _mouseEvent.X = (int)Input.mousePosition.x;
            _mouseEvent.Y = (int)Input.mousePosition.y;
            _mouseEvent.Button = "LeftButton";
            EventBus.Instance.Publish(inputChannel, _mouseEvent);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ScriptableObjects.EventBus.EventBus;
using ScriptableObjects.EventBus.Events;

public class InputManager : MonoBehaviour
{

    [SerializeField] private EvetBus eventBus;
    [SerializeField] private KeyboardEvent keyboardEvent;
    [SerializeField] private MouseEvent mouseEvent;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyboardEvent.Key = "Space";
            eventBus.Publish("InputChannel", keyboardEvent);
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseEvent.X = (int)Input.mousePosition.x;
            mouseEvent.Y = (int)Input.mousePosition.y;
            mouseEvent.Button = "LeftButton";
            eventBus.Publish("InputChannel", mouseEvent);
        }
    }
}

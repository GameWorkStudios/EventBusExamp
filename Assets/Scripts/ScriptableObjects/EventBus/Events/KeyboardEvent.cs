using UnityEngine;

namespace ScriptableObjects.EventBus.Events
{
    [CreateAssetMenu(fileName = "NewKeyboardEvent", menuName = "Events/KeyboardEvent")]
    public class KeyboardEvent : BaseEvent.BaseEvent
    {
        public string Key;
    }
}
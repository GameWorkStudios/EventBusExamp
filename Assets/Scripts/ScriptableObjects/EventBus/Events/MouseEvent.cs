using UnityEngine;

namespace ScriptableObjects.EventBus.Events
{
    [CreateAssetMenu(fileName = "NewMouseEvent", menuName = "Events/MouseEvent")]
    public class MouseEvent : BaseEvent.BaseEvent
    {
        public int X;
        public int Y;
        public string Button;
    }
}
using MVC.EventData;
using UnityEngine.Events;

namespace UnityEvents
{
    [System.Serializable]
    public class UnityEventPlayerModelAndTransform : UnityEvent<PlayerAndTransformEventData> { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using MVC.EventData;
using ScriptableObjects.EventSO;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.EventListener
{
    public class EventListener : MonoBehaviour
    {
        #region Properties
        [field: Header("Condition List is optional.")]
        [field: SerializeField] public List<Condition.Condition> ConditionsList { get; private set; }
        
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public List<EventPlayerModelAndTransformSO> TriggerEventsList { get; private set; }
        [field: SerializeField] public UnityEvent<PlayerAndTransformEventData> Handler { get; private set; }
        
        #endregion
        #region Monobehaviour

        private void OnEnable() => SubscribeToEvents();
        private void OnDisable() => UnsubscribeFromEvents();

        #endregion
        #region Methods
        
        private void SubscribeToEvents()
        {
            foreach (var triggerEvent in TriggerEventsList)
            {
                triggerEvent.UnityEvent.AddListener(Invoke);
            }
        }

        private void UnsubscribeFromEvents()
        {
            foreach (var triggerEvent in TriggerEventsList)
            {
                triggerEvent.UnityEvent.RemoveListener(Invoke);
            }
        }

        private void Invoke(PlayerAndTransformEventData context)
        {
            // Guard Clause: Check if any of the conditions are not met
            if (ConditionsList.Any(condition => !condition.IsMet(context))) return;
        
            Handler.Invoke(context);
        }
        
        #endregion
    }
}
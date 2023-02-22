using System.Collections.Generic;
using System.Linq;
using MVC.EventData;
using MVC.State;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using ScriptableObjects.TransitionDirectionSO;
using UnityEngine;

namespace MVC.StateTransition
{
    public class StateTransition : MonoBehaviour
    {
        #region Properties
        [field: SerializeField] public StateBehaviour StateToTransitionTo { get; protected set; }
        [field: SerializeField] public TransitionDirectionSO TransitionDirection { get; protected set; }
        [field: Header("Condition List is optional.")]
        [field: SerializeField] public List<Condition.Condition> ConditionsList { get; protected set; }
        
        #endregion
        #region Event Properties
        [field: SerializeField] public List<EventPlayerModelAndTransformSO> TriggerEventsList { get; protected set; }
        
        #endregion
        #region MonoBehaviour

        protected void OnEnable() => SubscribeToEvents();
        protected void OnDisable() => UnsubscribeFromEvents();
        
        #endregion
        #region Methods

        protected void SubscribeToEvents()
        {
            foreach (var triggerEvent in TriggerEventsList)
            {
                triggerEvent.UnityEvent.AddListener(TransitionToState);
            }
        }
        
        protected void UnsubscribeFromEvents()
        {
            foreach (var triggerEvent in TriggerEventsList)
            {
                triggerEvent.UnityEvent.RemoveListener(TransitionToState);
            }
        }

        public virtual void TransitionToState(PlayerAndTransformEventData context)
        {
            // Guard Clause: Check if any of the conditions are not met
            if (ConditionsList.Any(condition => !condition.IsMet(context))) return;
        
            TransitionDirection.TransitionToState(context, StateToTransitionTo);
        }

        #endregion
    }
}
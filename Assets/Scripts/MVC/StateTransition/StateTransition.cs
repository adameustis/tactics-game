using System.Collections.Generic;
using System.Linq;
using MVC.EventModel;
using MVC.State;
using ScriptableObjects.ConditionSO;
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
        [field: SerializeField] public List<ConditionSO> ConditionList { get; protected set; }

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

        protected virtual void TransitionToState(PlayerAndTransformEventModel context)
        {
            // Guard Clause: Check if any of the conditions are not met
            if (ConditionList.Any(condition => !condition.IsMet(context, transform))) return;
        
            TransitionDirection.TransitionToState(context, StateToTransitionTo);
        }

        #endregion
    }
}
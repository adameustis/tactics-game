using System;
using System.Collections.Generic;
using MVC.EventModel;
using UnityEngine;
using MVC.StateController;

namespace MVC.State
{
    public class StateBehaviour : MonoBehaviour
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateController.StateController Controller { get; protected set; }
        [field: SerializeField] public Queue<StateData> DataQueue { get; protected set; } = new();
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO OnEnter { get; protected set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO OnExit { get; protected set; }
        #endregion
        #region MonoBehaviour

        protected virtual void OnEnable() => SubscribeToEvents();
        protected void OnDisable() => UnsubscribeFromEvents();
        
        #endregion
        #region Methods

        protected virtual void SubscribeToEvents() {}
        protected virtual void UnsubscribeFromEvents() {}
        
        public virtual void EnterState(PlayerAndTransformEventModel context)
        {
            gameObject.SetActive(true);
            DataQueue.Enqueue(new StateData());
            OnEnter.UnityEvent.Invoke(context);
        }

        public virtual void ReturnToState(PlayerAndTransformEventModel context)
        {
            gameObject.SetActive(true);
            OnEnter.UnityEvent.Invoke(context);
        }
        
        public virtual void ExitState(PlayerAndTransformEventModel context, bool save)
        {
            if (!save)
                DataQueue.Dequeue();
            
            OnExit.UnityEvent.Invoke(context);
            gameObject.SetActive(false);
        }


        
        #endregion


    }
}

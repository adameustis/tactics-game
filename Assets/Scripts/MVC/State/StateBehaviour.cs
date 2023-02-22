using System;
using System.Collections.Generic;
using MVC.EventData;
using UnityEngine;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine.Events;

namespace MVC.State
{
    public class StateBehaviour : MonoBehaviour
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateMachine.StateMachine Machine { get; protected set; }
        [field: SerializeField] public List<StateData> DataQueue { get; protected set; } = new();
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO PublicOnEnter { get; protected set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO PublicOnExit { get; protected set; }
        [field: SerializeField] public UnityEvent<PlayerAndTransformEventData> LocalOnEnter { get; protected set; }
        [field: SerializeField] public UnityEvent<PlayerAndTransformEventData> LocalOnExit { get; protected set; }
        #endregion
        #region MonoBehaviour

        protected virtual void OnEnable() => SubscribeToEvents();
        protected void OnDisable() => UnsubscribeFromEvents();
        
        #endregion
        #region Methods

        protected virtual void SubscribeToEvents() {}
        protected virtual void UnsubscribeFromEvents() {}
        
        public virtual void EnterState(PlayerAndTransformEventData context)
        {
            gameObject.SetActive(true);
            DataQueue.Add(new StateData(context)); // Can record more than context if necessary
            PublicOnEnter.UnityEvent.Invoke(context);
            LocalOnEnter.Invoke(context);
        }

        public virtual void ReturnToState(PlayerAndTransformEventData context)
        {
            gameObject.SetActive(true);
            PublicOnEnter.UnityEvent.Invoke(context);
            LocalOnEnter.Invoke(context);
        }
        
        public virtual void ExitState(PlayerAndTransformEventData context, bool save)
        {
            if (!save)
                DataQueue.RemoveAt(DataQueue.Count - 1);
            
            PublicOnExit.UnityEvent.Invoke(context);
            LocalOnExit.Invoke(context);
            gameObject.SetActive(false);
        }


        
        #endregion


    }
}

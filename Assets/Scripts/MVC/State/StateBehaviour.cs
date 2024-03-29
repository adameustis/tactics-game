using System;
using System.Collections.Generic;
using System.Linq;
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
        [field: SerializeField] public List<PlayerAndTransformData> DataQueue { get; protected set; } = new();
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO PublicOnEnter { get; protected set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO PublicOnExit { get; protected set; }
        [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalOnEnter { get; protected set; }
        [field: SerializeField] public UnityEvent<PlayerAndTransformData> LocalOnExit { get; protected set; }
        #endregion
        #region MonoBehaviour

        protected virtual void OnEnable() => SubscribeToEvents();
        protected void OnDisable() => UnsubscribeFromEvents();
        
        #endregion
        #region Methods

        protected virtual void SubscribeToEvents() {}
        protected virtual void UnsubscribeFromEvents() {}
        
        public virtual void EnterState(PlayerAndTransformData context)
        {
            gameObject.SetActive(true);
            DataQueue.Add(context);
            PublicOnEnter.UnityEvent.Invoke(context);
            LocalOnEnter.Invoke(context);
        }

        public virtual void ReturnToState(PlayerAndTransformData context)
        {
            gameObject.SetActive(true);
            var returnedToStateData = DataQueue.Last();
            PublicOnEnter.UnityEvent.Invoke(returnedToStateData);
            LocalOnEnter.Invoke(returnedToStateData);
        }
        
        public virtual void ExitState(PlayerAndTransformData context, bool save)
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

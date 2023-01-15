using System.Collections.Generic;
using MVC.EventModel;
using MVC.State;
using UnityEngine;

namespace MVC.StateController
{
    public class StateController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public virtual Queue<StateBehaviour> StateQueue { get; set; } = new();
        [field: SerializeField] public virtual StateBehaviour DefaultState { get; protected set; }
        #endregion
        #region Event Properties
        #endregion
        #region Constructors
        #endregion
        #region MonoBehaviour

        protected virtual void OnEnable()
        {
            if (StateQueue.Count > 0)
                return;
            
            StateQueue.Enqueue(DefaultState);
            DefaultState.EnterState(new PlayerAndTransformEventModel(new PlayerModel(), transform)); // Player will need to come from somewhere
        }

        #endregion
        #region Event Handlers
        #endregion
        #region Method

        public virtual void AdvanceToState(PlayerAndTransformEventModel context, StateBehaviour setStateBehaviour, bool clearHistory)
        {
            StateBehaviour currentState = StateQueue.Peek();
            if (setStateBehaviour == currentState) return;
            
            currentState.ExitState(context, true);
            
            if (clearHistory) StateQueue.Clear();
            
            StateQueue.Enqueue(setStateBehaviour);
            setStateBehaviour.EnterState(context);
        }

        public virtual void ReturnToPreviousState(PlayerAndTransformEventModel context)
        {
            if (StateQueue.Count < 2)
                return;

            StateQueue.Dequeue().ExitState(context, false);
            StateQueue.Peek().ReturnToState(context);
        }

        #endregion
    }
}
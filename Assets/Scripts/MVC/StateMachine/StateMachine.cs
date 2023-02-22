using System.Collections.Generic;
using System.Linq;
using MVC.EventData;
using MVC.State;
using UnityEngine;

namespace MVC.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public virtual List<StateBehaviour> StateQueue { get; set; } = new();
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
            
            AdvanceToState(new PlayerAndTransformEventData(new PlayerModel(), transform), DefaultState, false); // Player will need to come from somewhere
        }

        #endregion
        #region Event Handlers
        #endregion
        #region Method

        public virtual void AdvanceToState(PlayerAndTransformEventData context, StateBehaviour setStateBehaviour, bool clearHistory)
        {
            if (StateQueue.Count > 0)
            {
                StateBehaviour currentState = StateQueue.Last();
                if (setStateBehaviour == currentState) return;

                currentState.ExitState(context, true);

                if (clearHistory) StateQueue.Clear();
            }

            StateQueue.Add(setStateBehaviour);
            setStateBehaviour.EnterState(context);
        }

        public virtual void ReturnToPreviousState(PlayerAndTransformEventData context)
        {
            if (StateQueue.Count < 2)
                return;
            StateQueue.Last().ExitState(context, false);
            StateQueue.RemoveAt(StateQueue.Count - 1);
            StateQueue.Last().ReturnToState(context);
        }

        #endregion
    }
}
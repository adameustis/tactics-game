using System;
using System.Collections.Generic;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.StateController
{
    public class BattleStateController : StateController
    {
        #region Fields
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public BattleStateManagerSO Manager { get; private set; }
        [field: SerializeField] public LinkedList<State.State> StateList { get; private set; } = new();
        [field: SerializeField] public State.State Idle { get; private set; }
        [field: SerializeField] public State.State Menu { get; private set; }
        [field: SerializeField] public State.State PerformingAbility { get; private set; }
        [field: SerializeField] public State.State Targeting { get; private set; }
        [field: SerializeField] public State.State UnitSelected { get; private set; }
        #endregion
        #region Event Properties
        #endregion
        #region Constructors
        #endregion
        #region MonoBehaviour

        private void OnEnable()
        {
            AdvanceState(Idle);
        }

        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        public void AdvanceState(State.State setState)
        {
            StateList.AddLast(setState);
            Manager.CurrentState = setState;
        }

        public void ReverseState()
        {
            if (StateList.Count < 2)
                return;
            
            StateList.RemoveLast();
            Manager.CurrentState = StateList.Last.Value;
        }
        
        #endregion
    }
}
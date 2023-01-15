using System;
using System.Collections.Generic;
using MVC.EventModel;
using MVC.State;
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
        [field: SerializeField] public StateManagerSO Manager { get; private set; }

        [field: SerializeField] public StateBehaviour MenuState { get; private set; }
        [field: SerializeField] public StateBehaviour UnitSelectedState { get; private set; }
        [field: SerializeField] public StateBehaviour TargetingState { get; private set; }
        [field: SerializeField] public StateBehaviour PerformingAbilityState { get; private set; }
        
        #endregion
        #region MonoBehaviour

        protected override void OnEnable()
        {
            if (StateQueue.Count > 0)
                return;
            StateQueue = Manager.BattleStateList;
            Manager.BattleStateList.Enqueue(DefaultState);
            DefaultState.EnterState(new PlayerAndTransformEventModel(new PlayerModel(), transform)); // Player will need to come from somewhere
        }
        
        #endregion

    }
}
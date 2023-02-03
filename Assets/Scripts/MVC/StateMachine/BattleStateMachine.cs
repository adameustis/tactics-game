using MVC.EventModel;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.StateMachine
{
    public class BattleStateMachine : StateMachine
    {
        #region Fields
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateManagerSO Manager { get; private set; }

        #endregion
        #region MonoBehaviour

        protected override void OnEnable()
        {
            if (StateQueue.Count > 0)
                return;
            StateQueue = Manager.BattleStateList;
            AdvanceToState(new PlayerAndTransformEventModel(new PlayerModel(), transform), DefaultState, false); // Player will need to come from somewhere
        }
        
        #endregion
    }
}
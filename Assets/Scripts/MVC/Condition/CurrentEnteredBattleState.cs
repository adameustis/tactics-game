using System.Linq;
using MVC.EventModel;
using ScriptableObjects.ConditionSO;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.Condition
{
    public class CurrentEnteredBattleState : Condition
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateManagerSO Manager { get; private set; }

        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO RequiredEnteredState { get; private set; }

        #endregion
        public override bool IsMet(PlayerAndTransformEventModel context)
        {
            return Manager.BattleStateList.Last().OnEnter == RequiredEnteredState;
        }
    }
}
using System.Linq;
using MVC.EventModel;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using ScriptableObjects.Manager;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    [CreateAssetMenu(fileName = "CurrentEnteredBattleState", menuName = "ScriptableObjects/Conditions/CurrentEnteredBattleState")]
    public class CurrentEnteredBattleState : ConditionSO
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateManagerSO Manager { get; private set; }

        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO RequiredEnteredState { get; private set; }

        #endregion
        public override bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform)
        {
            return Manager.BattleStateList.Last().OnEnter == RequiredEnteredState;
        }
    }
}
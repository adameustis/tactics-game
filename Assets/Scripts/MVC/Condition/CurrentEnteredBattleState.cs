using System.Linq;
using MVC.EventData;
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
        public override bool IsMet(PlayerAndTransformData context)
        {
            return Manager.BattleStateList.Last().PublicOnEnter == RequiredEnteredState;
        }
    }
}
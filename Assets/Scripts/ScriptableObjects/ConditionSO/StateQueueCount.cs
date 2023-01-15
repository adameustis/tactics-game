using MVC.EventModel;
using ScriptableObjects.Manager;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    [CreateAssetMenu(fileName = "StateQueueCount", menuName = "ScriptableObjects/Conditions/StateQueueCount")]
    public class StateQueueCount : ConditionSO
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateManagerSO Manager { get; private set; }
        [field: SerializeField] public int GreaterThan { get; private set; }

        #endregion
        #region Methods

        public override bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform)
        {
            return Manager.BattleStateList.Count > GreaterThan;
        }
        
        #endregion
    }
}
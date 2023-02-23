using MVC.EventData;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.Condition
{
    public class StateQueueCountGreaterThan : Condition
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public StateManagerSO Manager { get; private set; }
        [field: SerializeField] public int GreaterThan { get; private set; }

        #endregion
        #region Methods

        public override bool IsMet(PlayerAndTransformData context)
        {
            return Manager.BattleStateList.Count > GreaterThan;
        }
        
        #endregion
    }
}
using System.Collections.Generic;
using MVC.AbilityMenuItemDisplay;
using MVC.EventModel;
using ScriptableObjects.ConditionSO;
using UnityEngine;

namespace MVC.Condition
{
    public class AbilityUsesGreaterThan : Condition
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public AbilityController Controller { get; private set; }
        [field: SerializeField] public int GreaterThan { get; private set; }
        #endregion
        #region Methods
        
        public override bool IsMet(PlayerAndTransformEventModel context)
        {
            return Controller.Model.EffectiveUses > GreaterThan;
        }
        
        #endregion
    }
}
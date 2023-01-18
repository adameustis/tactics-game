using System.Collections.Generic;
using MVC.AbilityMenuItemDisplay;
using MVC.EventModel;
using UnityEngine;

namespace MVC.Condition
{
    public class AbilityUsesLessThan : Condition
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public AbilityBattleMenuItemController Controller { get; private set; }
        [field: SerializeField] public int LessThan { get; private set; }

        #endregion
        #region Methods
        
        public override bool IsMet(PlayerAndTransformEventModel context)
        {
            return Controller.Ability.EffectiveUses < LessThan;
        }
        
        #endregion
    }
}
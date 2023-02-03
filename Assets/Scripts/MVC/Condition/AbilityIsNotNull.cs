using System.Collections.Generic;
using MVC.Ability;
using MVC.AbilityMenuItemDisplay;
using MVC.EventModel;
using UnityEngine;

namespace MVC.Condition
{
    public class AbilityIsNotNull : Condition
    {
        #region Properties
        [field: SerializeField] public AbilityController Controller { get; private set; }
        #endregion
        #region Methods
        public override bool IsMet(PlayerAndTransformEventModel context)
        {
            return Controller.Model != null;
        }
        
        #endregion
    }
}
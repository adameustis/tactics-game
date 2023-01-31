using System.Collections.Generic;
using MVC.AbilityMenuItemDisplay;
using MVC.EventModel;
using ScriptableObjects.ConditionSO;
using UnityEngine;

namespace MVC.Condition
{
    public class AbilityIsNotNull : Condition
    {
        #region Properties
        [field: SerializeField] public AbilityDisplayController Controller { get; private set; }
        #endregion
        #region Methods
        public override bool IsMet(PlayerAndTransformEventModel context)
        {
            return Controller.Ability != null;
        }
        
        #endregion
    }
}
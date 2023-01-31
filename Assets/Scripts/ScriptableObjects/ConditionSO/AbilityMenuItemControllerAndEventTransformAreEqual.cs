using System.Collections.Generic;
using MVC.AbilityMenuItemDisplay;
using MVC.EventModel;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    [CreateAssetMenu(fileName = "AbilityMenuItemControllerAndEventTransformAreEqual", menuName = "ScriptableObjects/Conditions/AbilityMenuItemControllerAndEventTransformAreEqual")]
    public class AbilityMenuItemControllerAndEventTransformAreEqual : ConditionSO
    {
        #region Properties
        #endregion
        #region Methods
        public override bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform)
        {
            return context.Tf == componentTransform.GetComponentInParent<AbilityDisplayController>().transform;
        }
        
        #endregion
    }
}
using System.Collections.Generic;
using MVC.AbilityMenuItemDisplay;
using MVC.EventModel;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    [CreateAssetMenu(fileName = "UnitAbilityCountGreaterThanOrEqualSiblingIndex", menuName = "ScriptableObjects/Conditions/UnitAbilityCountGreaterThanOrEqualSiblingIndex")]
    public class UnitAbilityCountGreaterThanOrEqualSiblingIndex : ConditionSO
    {
        #region Properties
        #endregion
        #region Methods
        public override bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform)
        {
            List<AbilityModel> unitAbilities = context.Tf.GetComponent<UnitBattleController>().Model.UnitAbilities;
            int transformIndex = componentTransform.GetComponentInParent<AbilityDisplayController>().transform.GetSiblingIndex();
            return unitAbilities.Count >= transformIndex;
        }
        
        #endregion
    }
}
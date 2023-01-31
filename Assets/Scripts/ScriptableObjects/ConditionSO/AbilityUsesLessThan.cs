using System.Collections.Generic;
using MVC.AbilityMenuItemDisplay;
using MVC.EventModel;
using UnityEngine;

namespace ScriptableObjects.ConditionSO
{
    [CreateAssetMenu(fileName = "AbilityUsesLessThan", menuName = "ScriptableObjects/Conditions/AbilityUsesLessThan")]
    public class AbilityUsesLessThan : ConditionSO
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public int LessThan { get; private set; }

        #endregion
        #region Methods
        public override bool IsMet(PlayerAndTransformEventModel context, Transform componentTransform)
        {
            List<AbilityModel> unitAbilities = context.Tf.GetComponent<UnitBattleController>().Model.UnitAbilities;
            int transformIndex = componentTransform.GetComponentInParent<AbilityDisplayController>().transform.GetSiblingIndex();

            if (unitAbilities.Count < transformIndex) return false;
            
            return unitAbilities[transformIndex].EffectiveUses < LessThan;
        }
        
        #endregion
    }
}
using System.Collections.Generic;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.AbilityMenuItemDisplay
{
    public class SetAbilityBasedOnSelectedUnitAndSiblingIndex : MonoBehaviour
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public AbilityController Ability { get; private set; }
        [field: SerializeField] public UnitSelectionManagerSO UnitSelectionManager { get; private set; }
    
        #endregion
        
        
        public void UpdateAbility()
        {
            List<AbilityModel> unitAbilities = UnitSelectionManager.SelectedUnit.Model.UnitAbilities;
            int siblingIndex = transform.GetSiblingIndex();

            if (unitAbilities.Count < siblingIndex)
            {
                Ability = null;
                return;
            }

            Ability.Model = unitAbilities[siblingIndex];
        }
    }
}
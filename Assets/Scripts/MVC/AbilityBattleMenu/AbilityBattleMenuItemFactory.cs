using System.Collections.Generic;
using System.Linq;
using MVC.Ability;
using MVC.AbilityMenuItemDisplay;
using MVC.TargetingController;
using MVC.EventModel;
using MVC.Unit;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.Serialization;

namespace MVC.AbilityBattleMenu
{
    [System.Serializable]
    public class AbilityBattleMenuItemFactory : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public Transform TransformForeground { get; private set; }
        [field: SerializeField] public AbilityController UsableMenuItemPrefab { get; private set; }
        [field: SerializeField] public AbilityController UnusableMenuItemPrefab { get; private set; }
        [field: SerializeField] public List<AbilityController> MenuItemList { get; private set; }

        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
    
        public void DisplayEventHandler(PlayerAndTransformEventModel context)
        {
            if (context.Tf.TryGetComponent(out UnitController unit))
            {
                var unitAbilities = unit.Model.UnitAbilities;
                if (unitAbilities == null) return;
                Display(unitAbilities);
            }
        }
        
        public void StopDisplayHandler(PlayerAndTransformEventModel context)
        {
            ClearMenuItems();
        }
    
        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        private void Display(List<AbilityModel> abilityModelArray)
        {
            foreach (AbilityModel abilityModel in abilityModelArray)
                AddMenuItem(abilityModel);
        }

        private void AddMenuItem(AbilityModel abilityModel)
        {
            if (abilityModel == null) return;
            
            var abilityController = Instantiate(abilityModel.EffectiveUses > 0 ? UsableMenuItemPrefab : UnusableMenuItemPrefab, TransformForeground);
            abilityController.Initialise(abilityModel);
            MenuItemList.Add(abilityController);
        }

        private void ClearMenuItems()
        {
            if (MenuItemList == null) return;
            if (!MenuItemList.Any()) return;

            foreach (AbilityController controller in MenuItemList)
                Destroy(controller.gameObject);

            MenuItemList.Clear();
        }

        #endregion
    }
}

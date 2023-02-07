using System.Collections.Generic;
using System.Linq;
using MVC.Ability;
using MVC.EventModel;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Serialization;

namespace MVC.AbilityMenu
{
    [System.Serializable]
    public class AbilityMenuItemFactory : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private RectTransform transformToAttachMenuItemsTo;
        [SerializeField] private AbilityMenuItemController usableMenuItemPrefab;
        [SerializeField] private AbilityMenuItemController unusableMenuItemPrefab;
        [SerializeField] private List<AbilityMenuItemController> menuItemList;
        
        #endregion
        #region Events
        #endregion
        #region Properties
        
        public RectTransform TransformToAttachMenuItemsTo { get => transformToAttachMenuItemsTo; private set => transformToAttachMenuItemsTo = value; }
        public AbilityMenuItemController UsableMenuItemPrefab { get => usableMenuItemPrefab; private set => usableMenuItemPrefab = value; }
        public AbilityMenuItemController UnusableMenuItemPrefab { get => unusableMenuItemPrefab; private set => unusableMenuItemPrefab = value; }
        public List<AbilityMenuItemController> MenuItemList { get => menuItemList; private set => menuItemList = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
    
        public void DisplayEventHandler(PlayerAndTransformEventModel context)
        {
            if (context.Tf.TryGetComponent(out UnitController unit))
                Display(unit.Model);
        }
        
        public void StopDisplayHandler(PlayerAndTransformEventModel context)
        {
            ClearMenuItems();
        }
    
        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        private void Display(UnitModel unit)
        {
            var abilityList = unit.UnitAbilities;
            if (abilityList == null) return;
                
            foreach (var ability in abilityList)
                AddMenuItem(ability, unit);
        }

        private void AddMenuItem(AbilityModel ability, UnitModel unit)
        {
            if (ability == null) return;
            
            var menuItem = Instantiate(ability.EffectiveUses > 0 ? UsableMenuItemPrefab : UnusableMenuItemPrefab, TransformToAttachMenuItemsTo);
            //menuItem.transform.SetParent(TransformToAttachMenuItemsTo);
            menuItem.Initialise(ability, unit);
            MenuItemList.Add(menuItem);
        }

        private void ClearMenuItems()
        {
            if (MenuItemList == null) return;
            if (!MenuItemList.Any()) return;

            foreach (var menuItem in MenuItemList)
                Destroy(menuItem.gameObject);

            MenuItemList.Clear();
        }

        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using MVC.Ability;
using MVC.Cell;
using MVC.EventData;
using MVC.SelectArea;
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
    
        public void HandleOnEnterState(PlayerAndTransformData context)
        {
            // if (context.Tf.TryGetComponent(out SelectAreaController selectArea))
            //     Display(selectArea.Cell.CellResidentUnit, selectArea.Cell);

            if(context is SelectAreaData eventData)
                Display(eventData);
        }
        
        public void HandleOnExitState(PlayerAndTransformData context)
        {
            ClearMenuItems();
        }
    
        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        private void Display(SelectAreaData data)
        {
            var abilityList = data.SourceCell.CellResidentUnit.UnitAbilities;
            if (abilityList == null || !abilityList.Any()) return;
                
            foreach (var ability in abilityList)
                AddMenuItem(data, ability);
            
            MenuItemList[0].UIButton.Select();
        }

        private void AddMenuItem(SelectAreaData data, AbilityModel ability)
        {
            if (ability == null) return;
            
            var menuItem = Instantiate(ability.EffectiveUses > 0 ? UsableMenuItemPrefab : UnusableMenuItemPrefab, TransformToAttachMenuItemsTo);
            //menuItem.transform.SetParent(TransformToAttachSelectAreasTo);
            menuItem.Initialise(data, ability);
            menuItem.gameObject.SetActive(true);
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

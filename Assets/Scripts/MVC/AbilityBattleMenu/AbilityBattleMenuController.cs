using System.Collections.Generic;
using MVC.AbilityMenuItemDisplay;
using MVC.TargetingController;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.Serialization;

namespace MVC.AbilityBattleMenu
{
    [System.Serializable]
    public class AbilityBattleMenuController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public Transform TransformBackground { get; private set; }
        [field: SerializeField] public Transform TransformForeground { get; private set; }
        [field: SerializeField] public AbilityBattleMenuItemController MenuItemAvailablePrefab { get; private set; }
        [field: SerializeField] public AbilityBattleMenuItemController MenuItemNoUsesPrefab { get; private set; }
        [field: SerializeField] public List<AbilityBattleMenuItemController> MenuItemList { get; private set; }

        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> DisplayEvent { get; private set; }
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> StopDisplay { get; private set; }
    
        #endregion
        #region Event Subscriptions

        public void SubscribeToEvents()
        {
            // DisplayEvent.UnityEvent.AddListener(DisplayEventHandler);
            // StopDisplay.UnityEvent.AddListener(StopDisplayHandler);
        }

        public void UnsubscribeFromEvents()
        {
            // DisplayEvent.UnityEvent.RemoveListener(DisplayEventHandler);
            // StopDisplay.UnityEvent.RemoveListener(StopDisplayHandler);
        }

        #endregion
        #region Event Handlers
    
        // public void DisplayEventHandler(PlayerAndTransformEventModel eventModel)
        // {
        //     UnitBattleController unit = eventModel.Tf.GetComponent<UnitBattleController>();
        //     List<AbilityModel> abilityModelArray = unit.Model.UnitAbilities;
        //     if (abilityModelArray == null)
        //         return;
        //
        //     Display(abilityModelArray, unit);
        // }
        //
        // public void StopDisplayHandler(PlayerAndTransformEventModel eventModel)
        // {
        //     StopDisplaying();
        // }
    
        #endregion 
        #region MonoBehaviour

        public void OnEnable()
        {
            SubscribeToEvents();
        }

        public void OnDisable()
        {
            UnsubscribeFromEvents();
        }

        #endregion
        #region Methods

        public void Display(List<AbilityModel> abilityModelArray, UnitBattleController unit)
        {
            TransformBackground.gameObject.SetActive(true);
            DisplayList(abilityModelArray, unit);
        }

        public void StopDisplaying()
        {
            ClearMenuItems();
            TransformBackground.gameObject.SetActive(false);
        }
    
        public void DisplayList(List<AbilityModel> abilityModelArray, UnitBattleController unit)
        {
            foreach (AbilityModel abilityModel in abilityModelArray)
            {
                AddMenuItem(abilityModel, unit);
            }
        }

        public void AddMenuItem(AbilityModel abilityModel, UnitBattleController unit)
        {
            AbilityBattleMenuItemController abilityController;
            if (abilityModel.EffectiveUses < 1)
                abilityController = Instantiate(MenuItemNoUsesPrefab, TransformForeground);
            else
                abilityController = Instantiate(MenuItemAvailablePrefab, TransformForeground);
            
            abilityController.Initialise(abilityModel);
            MenuItemList.Add(abilityController);
        }

        public void ClearMenuItems()
        {
            if (MenuItemList == null) return;
            if (MenuItemList.Count == 0) return;

            foreach (AbilityBattleMenuItemController controller in MenuItemList)
            {
                Destroy(controller.gameObject);
            }

            MenuItemList.Clear();
        }

        #endregion
    }
}

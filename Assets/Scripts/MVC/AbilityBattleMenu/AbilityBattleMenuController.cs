using System.Collections.Generic;
using MVC.TargetingController;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.Serialization;

namespace MVC.AbilityBattleMenu
{
    [System.Serializable]
    public class AbilityBattleMenuController : MonoBehaviour
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] private Transform transformBackground;
        [SerializeField] private Transform transformForeground;
        [FormerlySerializedAs("menuDisplayPrefab")] [FormerlySerializedAs("menuItemPrefab")] [FormerlySerializedAs("abilityBattleMenuItemControllerPrefab")] [SerializeField] private AbilityController menuItemDisplayPrefab;
        [FormerlySerializedAs("abilityBattleDisplayControllerList")] [SerializeField] private List<AbilityController> menuItemList;

        #endregion
        #region Events

        [Header("Events")]
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> displayEvent;
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> stopDisplayEvent;

        #endregion
        #region Properties
        public Transform TransformBackground { get => transformBackground; set => transformBackground = value; }
        public Transform TransformForeground { get => transformForeground; set => transformForeground = value; }
        public AbilityController MenuItemDisplayPrefab { get => menuItemDisplayPrefab; set => menuItemDisplayPrefab = value; }
        public List<AbilityController> MenuItemList { get => menuItemList; set => menuItemList = value; }

        public virtual bool IsDisplaying
        {
            get
            {
                if (TransformBackground == null)
                    return false;
                return TransformBackground.gameObject.activeSelf;
            }
        }
    
        #endregion
        #region Event Properties

        public EventAbstractSO<UnityEventPlayerModelAndTransform> DisplayEvent { get => displayEvent; set => displayEvent = value; }
        public EventAbstractSO<UnityEventPlayerModelAndTransform> StopDisplay { get => stopDisplayEvent; set => stopDisplayEvent = value; }
    
        #endregion
        #region Event Subscriptions

        public void SubscribeToEvents()
        {
            DisplayEvent.UnityEvent.AddListener(DisplayEventHandler);
            StopDisplay.UnityEvent.AddListener(StopDisplayHandler);
        }

        public void UnsubscribeFromEvents()
        {
            DisplayEvent.UnityEvent.RemoveListener(DisplayEventHandler);
            StopDisplay.UnityEvent.RemoveListener(StopDisplayHandler);
        }

        #endregion
        #region Event Handlers
    
        public void DisplayEventHandler(PlayerAndTransformEventModel eventModel)
        {
            UnitBattleController unit = eventModel.Tf.GetComponent<UnitBattleController>();
            List<AbilityModel> abilityModelArray = unit.Model.UnitAbilities;
            if (abilityModelArray == null)
                return;
        
            Display(abilityModelArray, unit);
        }

        public void StopDisplayHandler(PlayerAndTransformEventModel eventModel)
        {
            StopDisplaying();
        }
    
        #endregion 
        #region MonoBehaviour

        public void Start()
        {
            Initialise();
        }

        public void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        #endregion
        #region Methods

        public void Initialise()
        {
            SubscribeToEvents();
        }

        public void Display(List<AbilityModel> abilityModelArray, UnitBattleController unit)
        {
            if (IsDisplaying)
                StopDisplaying();

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
            AbilityController abilityController = (AbilityController)Instantiate(MenuItemDisplayPrefab, TransformForeground);
            abilityController.Initialise(abilityModel);
            foreach (var targeting in abilityController.transform.GetComponents<TargetingController.TargetingController>())
            {
                targeting.Initialise(abilityModel, unit);
            }
            MenuItemList.Add(abilityController);
        }

        public void UpdateMenuItems(List<AbilityModel> abilityModelArray, UnitBattleController unit)
        {
            if(abilityModelArray == null)
                return;
            
            if (abilityModelArray.Count == 0)
                return;
        
            for (int i = 0; i < abilityModelArray.Count; i++)
            {
                if(i < MenuItemList.Count)
                {
                    UpdateMenuItem(i, abilityModelArray[i]);
                }
                else
                {
                    AddMenuItem(abilityModelArray[i], unit);
                }
            }
        }

        public void UpdateMenuItem(int index, AbilityModel abilityModel)
        {
            MenuItemList[index].Model = abilityModel;
        }

        public void ClearMenuItems()
        {
            if (MenuItemList == null)
            {
                // Do nothing
            }
            else if (MenuItemList.Count == 0)
            {
                // Do nothing
            }
            else
            {
                foreach (AbilityController controller in MenuItemList)
                {
                    Destroy(controller.gameObject);
                }
                MenuItemList.Clear();
            }
        }

        // public InstructionSO MouseOverAbilityMenuItem(AbilityMenuItemDisplayController abilityController)
        // {
        //     InstructionSO instruction = GameManager.InstructionManager.DoNothing;
        //     return instruction;
        // }
    
        // public InstructionSO SelectAbilityMenuItem(AbilityMenuItemDisplayController abilityController)
        // {
        //     InstructionSO instruction = GameManager.InstructionManager.DoNothing;
        //
        //     if (abilityController == null)
        //     {
        //         return instruction;
        //     }
        //
        //     AbilityModel abilityModel = abilityController.Model;
        //
        //     if (abilityModel.EffectiveUses < 1)
        //     {
        //         // TO DO EXPAND THIS TO ADD NO USES AVAILABLE FEEDBACK INSTRUCTION
        //         return instruction;
        //     }
        //
        //     Model.UnitEnergyUsed = Model.UnitEnergyUsed + abilityModel.Ability.Energy;
        //     abilityModel.EffectiveUses = abilityModel.EffectiveUses - 1;
        //
        //     if (abilityModel.EffectiveTargetingType == GameManager.TargetingTypeManager.TargetingTypeAdjacent)
        //     {
        //
        //     }
        //     else if (abilityModel.EffectiveTargetingType == GameManager.TargetingTypeManager.TargetingTypeAdjacentOrSelf)
        //     {
        //
        //     }
        //     else if (abilityModel.EffectiveTargetingType == GameManager.TargetingTypeManager.TargetingTypeInstant)
        //     {
        //         if (abilityModel.TargetEffectArray == null)
        //         {
        //             // Do nothing
        //         }
        //         else if (abilityModel.TargetEffectArray.Length > 0)
        //         {
        //             foreach (EffectModel effect in abilityModel.TargetEffectArray)
        //             {
        //                 if (effect.Target == GameManager.TargetManager.TargetSelfUnit)
        //                 {
        //                     ImplementEffect(effect);
        //                 }
        //                 else if (effect.Target == GameManager.TargetManager.TargetSelfCell)
        //                 {
        //                     // To do
        //                 }
        //                 else if (effect.Target == GameManager.TargetManager.TargetAllUnits)
        //                 {
        //                     foreach(UnitBattleController unitController in GameManager.UnitManager.UnitBattleControllerList)
        //                     {
        //                         unitController.ImplementEffect(effect);
        //                     }  
        //                 }
        //                 else if (effect.Target == GameManager.TargetManager.TargetAllAllies)
        //                 {
        //                     // To do
        //                 }
        //                 else if (effect.Target == GameManager.TargetManager.TargetAllEnemies)
        //                 {
        //                     // To do
        //                 }
        //                 else if (effect.Target == GameManager.TargetManager.TargetAllCells)
        //                 {
        //                     // To do
        //                 }
        //             }
        //         }
        //     }
        //     else if (abilityModel.EffectiveTargetingType == GameManager.TargetingTypeManager.TargetingTypeMove)
        //     {
        //         //Model.State = GameManager.StateManager.StateSOUnitChoosingWhereToMove;
        //     }
        //     else if (abilityModel.EffectiveTargetingType == GameManager.TargetingTypeManager.TargetingTypeRange)
        //     {
        //
        //     }
        //     else if (abilityModel.EffectiveTargetingType == GameManager.TargetingTypeManager.TargetingTypeThrough)
        //     {
        //
        //     }
        //
        //     return instruction;
        // }
    
        #endregion
    }
}

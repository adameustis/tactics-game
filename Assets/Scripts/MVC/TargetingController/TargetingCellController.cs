using MVC.EventModel;
using MVC.TargetCell;
using UnityEngine;

namespace MVC.TargetingController
{
    public class TargetingCellController : MonoBehaviour
    {
         #region Fields

        [SerializeField] private bool isTargeting;
        [SerializeField] private TargetCellController target;
        [SerializeField] private UnitBattleController sourceUnit;
        [SerializeField] private AbilityModel ability;

        #endregion
        #region Events
    
        [SerializeField] private EventPlayerModelAndTransformSO inputSubmit;
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputCancel;
        [SerializeField] private EventPlayerModelAndTransformSO cellMouseOn;

        #endregion
        #region Properties
    
        public bool IsTargeting
        {
            get => isTargeting;
            set => isTargeting = value;
        }

        public TargetCellController Target
        {
            get => target;
            set => target = value;
        }

        public UnitBattleController SourceUnit
        {
            get => sourceUnit;
            set => sourceUnit = value;
        }

        public AbilityModel Ability
        {
            get => ability;
            set => ability = value;
        }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO InputSubmit
        {
            get => inputSubmit;
            set => inputSubmit = value;
        }

        public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputCancel
        {
            get => genericInputCancel;
            set => genericInputCancel = value;
        }

        public EventPlayerModelAndTransformSO CellMouseOn
        {
            get => cellMouseOn;
            set => cellMouseOn = value;
        }

        #endregion
        #region Event Subscriptions

        public void SubscribeToEvents()
        {
            InputSubmit.UnityEvent.AddListener(InputSubmitHandler);
            GenericInputCancel.UnityEvent.AddListener(InputCancelHandler);
        }

        public void UnsubscribeFromEvents()
        {
            InputSubmit.UnityEvent.RemoveListener(InputSubmitHandler);
            GenericInputCancel.UnityEvent.RemoveListener(InputCancelHandler);
        }

        public void SubscribeToTargetEvents()
        {
            CellMouseOn.UnityEvent.AddListener(CellMouseOnHandler);
        }
        
        public void UnsubscribeFromTargetEvents()
        {
            CellMouseOn.UnityEvent.RemoveListener(CellMouseOnHandler);
        }
        
        #endregion
        #region Event Handlers
    
        public void InputSubmitHandler(PlayerAndTransformEventModel eventModel)
        {
            if (IsTargeting) return;
            
            if (eventModel.Tf != transform) return;
        
            StartTargeting(eventModel);
        }

        public void InputCancelHandler(PlayerAndTransformEventModel eventModel)
        {
            if (!IsTargeting) return;
            
            if (eventModel.Tf != transform) return;
        
            CancelTargeting(eventModel);
        }

        public void CellMouseOnHandler(PlayerAndTransformEventModel eventModel)
        {
            if (!IsTargeting) return;
            
            DisplayTarget(Ability, SourceUnit, eventModel.Tf.GetComponent<CellBattleController>());
        }

        #endregion 
        #region MonoBehaviour

        public void OnEnable()
        {
            SubscribeToEvents();
        }

        public void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        #endregion
        #region Methods

        public void Initialise(AbilityModel setAbility, UnitBattleController setSourceUnit)
        {
            Ability = setAbility;
            SourceUnit = setSourceUnit;
        }
        
        public void StartTargeting(PlayerAndTransformEventModel eventModel)
        {
            IsTargeting = true;
            SubscribeToTargetEvents();
        }
    
        public void CancelTargeting(PlayerAndTransformEventModel eventModel)
        {
            UnsubscribeFromTargetEvents();
            
            if (Target != null)
                Destroy(Target);

            Target = null;
            IsTargeting = false;
        }

        public void FinishTargeting(PlayerAndTransformEventModel eventModel, Transform target)
        {
            UnsubscribeFromTargetEvents();
        }

        public void DisplayTarget(AbilityModel abilityCast, UnitBattleController castingUnit, CellBattleController destinationCell)
        {
            Target = Instantiate(abilityCast.Ability.TargetCellPrefab, destinationCell.transform.position, Quaternion.identity);
            Target.Initialise(abilityCast, castingUnit, destinationCell);
        }
        
        #endregion
    }
}
using MVC.EventModel;
using MVC.Target;
using UnityEngine;

namespace MVC.TargetingController
{
    [System.Serializable]
    public class TargetingUnitController  : MonoBehaviour
    {
        #region Fields

        [SerializeField] private bool isTargeting;
        [SerializeField] private TargetUnitController targetUnit;
        [SerializeField] private UnitBattleController sourceUnit;
        [SerializeField] private AbilityModel ability;

        #endregion
        #region Events
    
        [SerializeField] private EventPlayerModelAndTransformSO inputSubmit;
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputCancel;
        [SerializeField] private EventPlayerModelAndTransformSO unitMouseOn;
        [SerializeField] private EventPlayerModelAndTransformSO beginTargetingEvent;
        [SerializeField] private EventPlayerModelAndTransformSO cancelTargetingEvent;
        [SerializeField] private EventPlayerModelAndTransformSO finishTargetingEvent;
        
        #endregion
        #region Properties
    
        public bool IsTargeting
        {
            get => isTargeting;
            set => isTargeting = value;
        }

        public TargetUnitController TargetUnit
        {
            get => targetUnit;
            set => targetUnit = value;
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

        public EventPlayerModelAndTransformSO UnitMouseOn
        {
            get => unitMouseOn;
            set => unitMouseOn = value;
        }

        public EventPlayerModelAndTransformSO BeginTargetingEvent
        {
            get => beginTargetingEvent;
            set => beginTargetingEvent = value;
        }

        public EventPlayerModelAndTransformSO CancelTargetingEvent
        {
            get => cancelTargetingEvent;
            set => cancelTargetingEvent = value;
        }

        public EventPlayerModelAndTransformSO FinishTargetingEvent
        {
            get => finishTargetingEvent;
            set => finishTargetingEvent = value;
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
            UnitMouseOn.UnityEvent.AddListener(UnitMouseOnHandler);
        }
        
        public void UnsubscribeFromTargetEvents()
        {
            UnitMouseOn.UnityEvent.AddListener(UnitMouseOnHandler);
        }
        
        #endregion
        #region Event Handlers
    
        public void InputSubmitHandler(PlayerAndTransformEventModel eventModel)
        {
            if (IsTargeting) return;
            
            if (eventModel.Tf != transform) return;
        
            BeginTargeting(eventModel);
        }

        public void InputCancelHandler(PlayerAndTransformEventModel eventModel)
        {
            if (!IsTargeting) return;
            
            if (eventModel.Tf != transform) return;
        
            CancelTargeting(eventModel);
        }

        public void UnitMouseOnHandler(PlayerAndTransformEventModel eventModel)
        {
            if (!IsTargeting) return;
            DisplayTarget(Ability, SourceUnit, eventModel.Tf.GetComponent<UnitBattleController>());
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
        
        public void BeginTargeting(PlayerAndTransformEventModel eventModel)
        {
            IsTargeting = true;
            SubscribeToTargetEvents();
            BeginTargetingEvent.UnityEvent.Invoke(eventModel);
        }
    
        public void CancelTargeting(PlayerAndTransformEventModel eventModel)
        {
            UnsubscribeFromTargetEvents();
            
            if (TargetUnit != null)
                Destroy(TargetUnit);

            TargetUnit = null;
            IsTargeting = false;
            CancelTargetingEvent.UnityEvent.Invoke(eventModel);
        }

        public void FinishTargeting(PlayerAndTransformEventModel eventModel, Transform target)
        {
            UnsubscribeFromTargetEvents();
            FinishTargetingEvent.UnityEvent.Invoke(eventModel);
        }

        public void DisplayTarget(AbilityModel abilityCast, UnitBattleController castingUnit, UnitBattleController destinationUnit)
        {
            TargetUnit = Instantiate(abilityCast.Ability.TargetUnitPrefab, destinationUnit.transform.position - new Vector3(0,0,3), Quaternion.identity);
            TargetUnit.Initialise(abilityCast, castingUnit, destinationUnit);
        }

        #endregion
    }
}

using MVC.EventData;
using MVC.Target;
using MVC.Unit;
using ScriptableObjects.EventSO;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEvents;

namespace MVC.TargetingController
{
    public class TargetingController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TargetController target;
        [SerializeField] private bool isTargeting;
        [SerializeField] private UnitController sourceUnit;
        [SerializeField] private AbilityModel ability;

        #endregion
        #region Events
        
        [SerializeField] private EventPlayerModelAndTransformSO inputSubmit;
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputCancel;
        [SerializeField] private EventPlayerModelAndTransformSO mouseOnCell;
        [SerializeField] private EventPlayerModelAndTransformSO mouseOnUnit;
        [SerializeField] private EventPlayerModelAndTransformSO beginTargetingEvent;
        [SerializeField] private EventPlayerModelAndTransformSO cancelTargetingEvent;
        [SerializeField] private EventPlayerModelAndTransformSO finishTargetingEvent;
        
        #endregion
        #region Properties

        public TargetController Target
        {
            get => target;
            set => target = value;
        }

        public bool IsTargeting
        {
            get => isTargeting;
            set => isTargeting = value;
        }

        public UnitController SourceUnit
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

        public EventPlayerModelAndTransformSO MouseOnCell
        {
            get => mouseOnCell;
            set => mouseOnCell = value;
        }

        public EventPlayerModelAndTransformSO MouseOnUnit
        {
            get => mouseOnUnit;
            set => mouseOnUnit = value;
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
            MouseOnUnit.UnityEvent.AddListener(MouseOnUnitHandler);
            MouseOnCell.UnityEvent.AddListener(MouseOnCellHandler);
        }
        
        public void UnsubscribeFromTargetEvents()
        {
            MouseOnUnit.UnityEvent.RemoveListener(MouseOnUnitHandler);
            MouseOnCell.UnityEvent.RemoveListener(MouseOnCellHandler);
        }
        
        #endregion
        #region Event Handlers
    
        public void InputSubmitHandler(PlayerAndTransformData data)
        {
            if (IsTargeting) return;
            
            if (data.Tf != transform) return;
        
            BeginTargeting(data);
        }

        public void InputCancelHandler(PlayerAndTransformData data)
        {
            if (!IsTargeting) return;
            
            CancelTargeting(data);
        }

        public void MouseOnUnitHandler(PlayerAndTransformData data)
        {
            if (!IsTargeting) return;
            DisplayTarget(Ability, SourceUnit, data.Tf, Ability.Ability.TargetUnitPrefab);
        }
        
        public void MouseOnCellHandler(PlayerAndTransformData data)
        {
            if (!IsTargeting) return;
            DisplayTarget(Ability, SourceUnit, data.Tf, Ability.Ability.TargetCellPrefab);
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

        public void Initialise(AbilityModel setAbility, UnitController setSourceUnit)
        {
            Ability = setAbility;
            SourceUnit = setSourceUnit;
        }
        
        public void BeginTargeting(PlayerAndTransformData data)
        {
            IsTargeting = true;
            SubscribeToTargetEvents();
            BeginTargetingEvent.UnityEvent.Invoke(data);
        }
    
        public void CancelTargeting(PlayerAndTransformData data)
        {
            UnsubscribeFromTargetEvents();
            Target = null;
            IsTargeting = false;
            CancelTargetingEvent.UnityEvent.Invoke(data);
        }

        public void FinishTargeting(PlayerAndTransformData data, Transform targetTF)
        {
            UnsubscribeFromTargetEvents();
            FinishTargetingEvent.UnityEvent.Invoke(data);
        }

        public void DisplayTarget(AbilityModel abilityCast, UnitController castingUnit, Transform destination, TargetController prefab)
        {
            Target = Instantiate(prefab, destination.position - new Vector3(0,0,3), Quaternion.identity);
            Target.Initialise(abilityCast, castingUnit, destination);
        }

        #endregion
    }
}
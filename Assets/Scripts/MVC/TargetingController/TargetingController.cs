using MVC.EventModel;
using MVC.Target;
using UnityEngine;

namespace MVC.TargetingController
{
    [System.Serializable]
    public class TargetingController  : MonoBehaviour
    {
        #region Fields

        [SerializeField] private bool isTargeting;
        [SerializeField] private TargetController targetPrefab;
        [SerializeField] private TargetController target;
        [SerializeField] private UnitBattleController sourceUnit;

        #endregion
        #region Events
    
        [SerializeField] private EventPlayerModelAndTransformSO inputSubmit;
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputCancel;
        [SerializeField] private EventPlayerModelAndTransformSO cellMouseOn;
        [SerializeField] private EventPlayerModelAndTransformSO unitMouseOn;
        
        #endregion
        #region Properties
    
        public bool IsTargeting
        {
            get => isTargeting;
            set => isTargeting = value;
        }

        public TargetController TargetPrefab
        {
            get => targetPrefab;
            set => targetPrefab = value;
        }

        public TargetController Target
        {
            get => target;
            set => target = value;
        }

        public UnitBattleController SourceUnit
        {
            get => sourceUnit;
            set => sourceUnit = value;
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

        public EventPlayerModelAndTransformSO UnitMouseOn
        {
            get => unitMouseOn;
            set => unitMouseOn = value;
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
            UnitMouseOn.UnityEvent.AddListener(UnitMouseOnHandler);
        }
        
        public void UnsubscribeFromTargetEvents()
        {
            CellMouseOn.UnityEvent.RemoveListener(CellMouseOnHandler);
            UnitMouseOn.UnityEvent.AddListener(UnitMouseOnHandler);
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
            
            DisplayTarget(eventModel);
        }
        
        public void UnitMouseOnHandler(PlayerAndTransformEventModel eventModel)
        {
            if (!IsTargeting) return;
            
            DisplayTarget(eventModel);
        }
        
        #endregion 
        #region MonoBehaviour

        public void OnEnable()
        {
            SubscribeToEvents();
            TargetPrefab = GetComponent<AbilityController>().Model.Ability.TargetPrefab;
        }

        public void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        #endregion
        #region Methods

        public void Initialise(TargetController setTargetPrefab, UnitBattleController setSourceUnit)
        {
            
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

        public void DisplayTarget(PlayerAndTransformEventModel eventModel)
        {
            Target = Instantiate(TargetPrefab, eventModel.Tf.position, Quaternion.identity);
            Target.Initialise()
        }
        
        #endregion
    }
}

using MVC.EventModel;
using UnityEngine;

namespace MVC.Move
{
    public class MoveController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public UnitModel Model { get; private set; }
        [field: SerializeField] public bool IsMoving { get; private set; }
        [field: SerializeField] public bool IsLocked { get; private set; }

        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO InputSubmit { get; private set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO InputCancel { get; private set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO BeginMovingEvent { get; private set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO CellMouseOn { get; private set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO BeginTargeting { get; private set; }
        [field: SerializeField] public EventPlayerModelAndTransformSO CancelTargeting { get; private set; }

        #endregion
        #region Event Subscriptions

        public void SubscribeToUnselectedOnTurnEvents()
        {
        
        }

        public void UnsubscribeFromUnselectOnTurnEvents()
        {
        
        }

        public void SubscribeToMovingEvents()
        {
            CellMouseOn.UnityEvent.AddListener(HandleCellMouseOnWhilstMoving);
            InputSubmit.UnityEvent.AddListener(HandleInputSubmitWhilstMoving);
            InputCancel.UnityEvent.AddListener(HandleInputCancelWhilstMoving);
            BeginTargeting.UnityEvent.AddListener(HandleBeginTargetingWhilstMoving);
        }

        public void UnsubscribeFromMovingEvents()
        {
            CellMouseOn.UnityEvent.RemoveListener(HandleCellMouseOnWhilstMoving);
            InputSubmit.UnityEvent.RemoveListener(HandleInputSubmitWhilstMoving);
            InputCancel.UnityEvent.RemoveListener(HandleInputCancelWhilstMoving);
            BeginTargeting.UnityEvent.RemoveListener(HandleBeginTargetingWhilstMoving);
        }

        public void SubscribeToLockEvents()
        {
            InputCancel.UnityEvent.AddListener(HandleInputCancelWhilstLocked);
            BeginTargeting.UnityEvent.AddListener(HandleBeginTargetingWhilstLocked);
        }

        public void UnsubscribeToLockEvents()
        {
            InputCancel.UnityEvent.RemoveListener(HandleInputCancelWhilstLocked);
            BeginTargeting.UnityEvent.RemoveListener(HandleBeginTargetingWhilstLocked);
        }
    
        public void SubscribeToTargetingEvents()
        {
            CancelTargeting.UnityEvent.AddListener(HandleCancelTargeting);
        }

        public void UnsubscribeFromTargetingEvents()
        {
            CancelTargeting.UnityEvent.RemoveListener(HandleCancelTargeting);
        }
    
        #endregion
        #region Event Handlers

        public void HandleInputSubmitWhilstMoving(PlayerAndTransformEventModel context)
        {
            if (!IsMoving)
                return;
        
            if (context.Tf != transform)
                return;
        
            StopMovingState(context);
            StartLockState(context);
        }
    
        public void HandleInputCancelWhilstMoving(PlayerAndTransformEventModel context)
        {
            if (!IsMoving)
                return;
        
            if (context.Tf != transform)
                return;

            StopMovingState(context);
        }

        public void HandleInputCancelWhilstLocked(PlayerAndTransformEventModel context)
        {
            if (!IsMoving)
                return;

            StopLockState(context);
            StartMovingState(context);
        }

        public void HandleCellMouseOnWhilstMoving(PlayerAndTransformEventModel context)
        {
            if (!IsMoving)
                return;

            Model.TransformPosition = context.Tf.position;
            Model.UnitCellResidence = context.Tf.GetComponent<CellBattleController>().Model;
        }

        public void HandleBeginTargetingWhilstMoving(PlayerAndTransformEventModel context)
        {
            if (!IsMoving) return;
        
            StopMovingState(context);
        }
    
        public void HandleBeginTargetingWhilstLocked(PlayerAndTransformEventModel context)
        {
            if (!IsLocked) return;
        
            StopLockState(context);
        }

        public void HandleCancelTargeting(PlayerAndTransformEventModel context)
        {
            if (IsLocked)
                StartLockState(context); 
            else
                StartMovingState(context);
        }
    
        #endregion
        #region Monobehaviour

        public void Start()
        {
            if (TryGetComponent(out UnitBattleController unit))
                Model = unit.Model;

            SubscribeToUnselectedOnTurnEvents();
        }

        public void OnDestroy()
        {
            UnsubscribeFromUnselectOnTurnEvents();
        }
    
        #endregion
        #region Methods

        public void StartMovingState(PlayerAndTransformEventModel context)
        {
            IsMoving = true;
            BeginMovingEvent.UnityEvent.Invoke(context);
            SubscribeToMovingEvents();
        }

        public void StopMovingState(PlayerAndTransformEventModel context)
        {
            IsMoving = false;
            UnsubscribeFromMovingEvents();
        }
    
        public void StartLockState(PlayerAndTransformEventModel context)
        {
            if (IsLocked)
                return;

            IsLocked = true;

        }

        public void StopLockState(PlayerAndTransformEventModel context)
        {
            if (!IsLocked)
                return;

            IsLocked = false;

        }


        #endregion
    }
}

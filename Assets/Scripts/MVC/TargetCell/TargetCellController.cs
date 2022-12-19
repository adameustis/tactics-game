using MVC.EventModel;
using UnityEngine;

namespace MVC.TargetCell
{
    public class TargetCellController : MonoBehaviour
    {
                #region Fields
   
        [SerializeField] protected Animator targetAnimator;
        [SerializeField] protected AbilityModel ability;
        [SerializeField] protected UnitBattleController sourceUnit;
        [SerializeField] protected CellBattleController destinationCell;

        #endregion
        #region Events
    
        [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> mouseOff;
        [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> inputSubmit;
        protected static readonly int Valid = Animator.StringToHash("valid");

        #endregion
        #region Properties
    
        public virtual Animator TargetAnimator { get => targetAnimator; set => targetAnimator = value; }

        public virtual AbilityModel Ability
        {
            get => ability;
            set => ability = value;
        }

        public virtual UnitBattleController SourceUnit
        {
            get => sourceUnit;
            set => sourceUnit = value;
        }

        public virtual CellBattleController DestinationCell
        {
            get => destinationCell;
            set => destinationCell = value;
        }

        #endregion
        #region Event Properties
    
        public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> MouseOff { get => mouseOff; set => mouseOff = value; }

        public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> InputSubmit
        {
            get => inputSubmit;
            set => inputSubmit = value;
        }

        #endregion
        #region Event Subscriptions

        public virtual void SubscribeToEvents()
        {
            MouseOff.UnityEvent.AddListener(MouseOffHandler);
            InputSubmit.UnityEvent.AddListener(InputSubmitHandler);
        }

        public virtual void UnsubscribeFromEvents()
        {
            MouseOff.UnityEvent.RemoveListener(MouseOffHandler);
            InputSubmit.UnityEvent.RemoveListener(InputSubmitHandler);
        }

        #endregion
        #region Event Handlers
    
        public virtual void MouseOffHandler(PlayerAndTransformEventModel eventModel)
        {
            if (eventModel.Tf != transform) return;
            Destroy(gameObject);
        }

        public virtual void InputSubmitHandler(PlayerAndTransformEventModel eventModel)
        {
            
        }
        
        #endregion 
        #region MonoBehaviour

        public virtual void Initialise(AbilityModel setAbility, UnitBattleController setSourceUnit, CellBattleController setDestinationCell)
        {
            Ability = setAbility;
            SourceUnit = setSourceUnit;
            DestinationCell = setDestinationCell;
            SubscribeToEvents();
        }

        public virtual void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        #endregion
        #region Methods

        public virtual void Display()
        {
            TargetAnimator.SetBool(Valid, true);
        }

        #endregion
    }
}
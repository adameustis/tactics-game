﻿using MVC.EventData;
using MVC.Unit;
using ScriptableObjects.EventSO;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEvents;

namespace MVC.Target
{
    [System.Serializable]
    public class TargetController : MonoBehaviour
    {
        #region Fields
   
        [SerializeField] protected Animator targetAnimator;
        [SerializeField] protected AbilityModel ability;
        [SerializeField] protected UnitController sourceUnit;
        [SerializeField] protected Transform target;

        #endregion
        #region Events
    
        [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> mouseOff;
        [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> inputSubmit;
        [SerializeField] protected EventPlayerModelAndTransformSO cancelTargeting;
        protected static readonly int Valid = Animator.StringToHash("valid");

        #endregion
        #region Properties
    
        public virtual Animator TargetAnimator { get => targetAnimator; set => targetAnimator = value; }

        public virtual AbilityModel Ability
        {
            get => ability;
            set => ability = value;
        }

        public virtual UnitController SourceUnit
        {
            get => sourceUnit;
            set => sourceUnit = value;
        }

        public virtual Transform Target
        {
            get => target;
            set => target = value;
        }

        #endregion
        #region Event Properties
    
        public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> MouseOff { get => mouseOff; set => mouseOff = value; }

        public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> InputSubmit
        {
            get => inputSubmit;
            set => inputSubmit = value;
        }

        public EventPlayerModelAndTransformSO CancelTargeting
        {
            get => cancelTargeting;
            set => cancelTargeting = value;
        }

        #endregion
        #region Event Subscriptions

        public virtual void SubscribeToEvents()
        {
            MouseOff.UnityEvent.AddListener(MouseOffHandler);
            InputSubmit.UnityEvent.AddListener(InputSubmitHandler);
            CancelTargeting.UnityEvent.AddListener(CancelTargetingHandler);
        }

        public virtual void UnsubscribeFromEvents()
        {
            MouseOff.UnityEvent.RemoveListener(MouseOffHandler);
            InputSubmit.UnityEvent.RemoveListener(InputSubmitHandler);
            CancelTargeting.UnityEvent.RemoveListener(CancelTargetingHandler);
        }

        #endregion
        #region Event Handlers
    
        public virtual void MouseOffHandler(PlayerAndTransformData data)
        {
            if (data.Tf != transform) return;
            Destroy(gameObject);
        }

        public virtual void InputSubmitHandler(PlayerAndTransformData data)
        {
            
        }

        public virtual void CancelTargetingHandler(PlayerAndTransformData data)
        {
            Destroy(gameObject);
        }
        
        #endregion 
        #region MonoBehaviour

        public virtual void Initialise(AbilityModel setAbility, UnitController setSourceUnit, Transform setTarget)
        {
            Ability = setAbility;
            SourceUnit = setSourceUnit;
            Target = setTarget;
            SubscribeToEvents();
            Display();
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

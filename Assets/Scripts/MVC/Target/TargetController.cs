using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TargetController : MonoBehaviour
{
   #region Fields
   
   [SerializeField] protected Animator targetAnimator;
   [SerializeField] protected TargetModel model;

   #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOff;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOn;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventActive;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInactive;
    
    #endregion
    #region Properties
    
    public virtual Animator OutlineAnimator { get => targetAnimator; set => targetAnimator = value; }
    public virtual bool IsDisplaying { get => OutlineAnimator.GetBool("isDisplaying"); }
    public TargetModel Model { get => model; set => model = value; }
    
    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOff { get => eventInputMouseOff; set => eventInputMouseOff = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOn { get => eventInputMouseOn; set => eventInputMouseOn = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventActive { get => eventActive; set => eventActive = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInactive { get => eventInactive; set => eventInactive = value; }
    
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        EventInputMouseOff.UnityEvent.AddListener(MouseOffEventHandler);
        EventInputMouseOn.UnityEvent.AddListener(MouseOnEventHandler);
        EventActive.UnityEvent.AddListener(ActiveHandler);
        EventInactive.UnityEvent.AddListener(InactiveHandler);
    }

    public void UnsubscribeFromEvents()
    {
        EventInputMouseOff.UnityEvent.RemoveListener(MouseOffEventHandler);
        EventInputMouseOn.UnityEvent.RemoveListener(MouseOnEventHandler);
        EventActive.UnityEvent.RemoveListener(ActiveHandler);
        EventInactive.UnityEvent.RemoveListener(InactiveHandler);
    }

    #endregion
    #region Event Handlers
    
    public void MouseOffEventHandler(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform || !Model.IsActive) return;
        StopDisplaying();
    }

    public void MouseOnEventHandler(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform || !Model.IsActive) return;
        Display();
    }
    
    public void ActiveHandler(PlayerAndTransformEventModel eventModel)
    {
        Active();
    }
    
    public void InactiveHandler(PlayerAndTransformEventModel eventModel)
    {
        Inactive();
    }
    
    #endregion 
    #region MonoBehaviour

    public void Start()
    {
        SubscribeToEvents();
    }

    public void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    #endregion
    #region Methods
    public void StopDisplaying()
    {
        OutlineAnimator.SetBool("isDisplaying", false);
    }

    public void Display()
    {
        OutlineAnimator.SetBool("isDisplaying", true);
    }

    public void Active()
    {
        Model.IsActive = true;
    }
    
    public void Inactive()
    {
        Model.IsActive = false;
    }
    
    #endregion
}

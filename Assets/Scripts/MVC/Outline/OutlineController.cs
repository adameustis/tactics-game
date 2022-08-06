using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    #region Fields
    
    [SerializeField] protected Animator outlineAnimator;

    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventForDisplay;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventForStopDisplay;
   
    #endregion
    #region Properties
    public virtual Animator OutlineAnimator { get => outlineAnimator; set => outlineAnimator = value; }
    public virtual bool IsDisplaying { get => OutlineAnimator.GetBool("isDisplaying"); }

    #endregion
    #region Event Properties

    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventForDisplay { get => eventForDisplay; set => eventForDisplay = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventForStopDisplay { get => eventForStopDisplay; set => eventForStopDisplay = value; }
    
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        EventForStopDisplay.UnityEvent.AddListener(StopDisplayingOutline);
        EventForDisplay.UnityEvent.AddListener(DisplayOutline);
    }

    public void UnsubscribeFromEvents()
    {
        EventForStopDisplay.UnityEvent.RemoveListener(StopDisplayingOutline);
        EventForDisplay.UnityEvent.RemoveListener(DisplayOutline);
    }

    #endregion
    #region Methods

    public virtual void DisplayOutline(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform) return;
        
        OutlineAnimator.SetBool("isDisplaying", true);
    }

    public virtual void StopDisplayingOutline(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform) return;
        
        OutlineAnimator.SetBool("isDisplaying", false);
    }

    #endregion
}

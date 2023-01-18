using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;

public class SelectionOutlineController : MonoBehaviour
{
    #region Fields
   
   [SerializeField] protected Animator outlineAnimator;
   
    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventDeselect;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventSelect;

    #endregion
    #region Properties
    
    public virtual Animator OutlineAnimator { get => outlineAnimator; set => outlineAnimator = value; }
    public virtual bool IsDisplaying { get => OutlineAnimator.GetBool("isDisplaying"); }
    
    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventDeselect { get => eventDeselect; set => eventDeselect = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventSelect { get => eventSelect; set => eventSelect = value; }
    
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        EventDeselect.UnityEvent.AddListener(SelectEventHandler);
        EventSelect.UnityEvent.AddListener(DeselectEventHandler);
    }

    public void UnsubscribeFromEvents()
    {
        EventDeselect.UnityEvent.RemoveListener(SelectEventHandler);
        EventSelect.UnityEvent.RemoveListener(DeselectEventHandler);
    }

    #endregion
    #region Event Handlers
    
    public void SelectEventHandler(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform) return;
        
        StopDisplayingOutline();
    }

    public void DeselectEventHandler(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform) return;
        
        DisplayOutline();
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
    public void StopDisplayingOutline()
    {
        OutlineAnimator.SetBool("isDisplaying", false);
    }

    public void DisplayOutline()
    {
        OutlineAnimator.SetBool("isDisplaying", true);
    }

    #endregion
}

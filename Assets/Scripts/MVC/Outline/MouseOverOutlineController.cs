using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.Events;
using UnityEvents;

[System.Serializable]
public class MouseOverOutlineController : MonoBehaviour
{
   #region Fields
   
   [SerializeField] protected Animator outlineAnimator;
   
    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOff;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOn;
    private static readonly int Displaying = Animator.StringToHash("isDisplaying");

    #endregion
    #region Properties
    
    public virtual Animator OutlineAnimator { get => outlineAnimator; set => outlineAnimator = value; }
    public virtual bool IsDisplaying => OutlineAnimator.GetBool(Displaying);

    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOff { get => eventInputMouseOff; set => eventInputMouseOff = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOn { get => eventInputMouseOn; set => eventInputMouseOn = value; }
    
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        EventInputMouseOff.UnityEvent.AddListener(MouseOffEventHandler);
        EventInputMouseOn.UnityEvent.AddListener(MouseOnEventHandler);
    }

    public void UnsubscribeFromEvents()
    {
        EventInputMouseOff.UnityEvent.RemoveListener(MouseOffEventHandler);
        EventInputMouseOn.UnityEvent.RemoveListener(MouseOnEventHandler);
    }

    #endregion
    #region Event Handlers
    
    public void MouseOffEventHandler(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform) return;
        
        StopDisplayingOutline();
    }

    public void MouseOnEventHandler(PlayerAndTransformEventModel eventModel)
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
        OutlineAnimator.SetBool(Displaying, false);
    }

    public void DisplayOutline()
    {
        OutlineAnimator.SetBool(Displaying, true);
    }

    #endregion
}

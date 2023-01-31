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
    private static readonly int Displaying = Animator.StringToHash("isDisplaying");

    #endregion
    #region Properties
    
    public virtual Animator OutlineAnimator { get => outlineAnimator; set => outlineAnimator = value; }
    public virtual bool IsDisplaying => OutlineAnimator.GetBool(Displaying);

    #endregion
    #region Event Properties

    #endregion
    #region Event Subscriptions
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
    #endregion
    #region Methods

    private void StopDisplayingOutline()
    {
        OutlineAnimator.SetBool(Displaying, false);
    }

    private void DisplayOutline()
    {
        OutlineAnimator.SetBool(Displaying, true);
    }

    #endregion
}

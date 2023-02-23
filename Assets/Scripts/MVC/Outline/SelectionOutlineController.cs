using System.Collections;
using System.Collections.Generic;
using MVC.EventData;
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
    
    public void SelectEventHandler(PlayerAndTransformData data)
    {
        if (data.Tf != transform) return;
        
        StopDisplayingOutline();
    }

    public void DeselectEventHandler(PlayerAndTransformData data)
    {
        if (data.Tf != transform) return;
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    #region Fields

    [SerializeField] protected Animator highlightAnimator;

    #endregion
    #region Events
    #endregion
    #region Properties

    public virtual Animator HighlightAnimator { get => highlightAnimator; set => highlightAnimator = value; }
    public virtual bool IsDisplaying { get => HighlightAnimator.GetBool("isDisplaying"); }

    #endregion
    #region Event Properties

    #endregion
    #region Methods

    public virtual void Display(bool pathable, bool canPassThrough, bool inRange)
    {
        HighlightAnimator.SetBool("isDisplaying", false); //To reset
        HighlightAnimator.SetBool("isDisplaying", true);
        HighlightAnimator.SetBool("pathable", pathable);
        HighlightAnimator.SetBool("canPassThrough", canPassThrough);
        HighlightAnimator.SetBool("inRange", inRange);
    }

    public virtual void StopDisplaying()
    {
        HighlightAnimator.SetBool("isDisplaying", false);
    }

    #endregion
}

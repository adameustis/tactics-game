using System.Collections;
using System.Collections.Generic;
using MVC.EventData;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEvents;

public class MouseOverHighlightCellPathingController : MonoBehaviour
{
    #region Fields
    
    [SerializeField] protected Animator highlightAnimator;

    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOff;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOn;
    private static readonly int Pathable = Animator.StringToHash("pathable");
    private static readonly int CanPassThrough = Animator.StringToHash("canPassThrough");
    private static readonly int InRange = Animator.StringToHash("inRange");
    private static readonly int Displaying = Animator.StringToHash("isDisplaying");

    #endregion
    #region Properties
    
    public virtual Animator HighlightAnimator { get => highlightAnimator; set => highlightAnimator = value; }
    public virtual bool IsDisplaying { get => HighlightAnimator.GetBool("isDisplaying"); }

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
    
    public void MouseOffEventHandler(PlayerAndTransformData data)
    {
        if (data.Tf != transform) return;
        
        StopDisplaying(data.Player);
    }

    public void MouseOnEventHandler(PlayerAndTransformData data)
    {
        if (data.Tf != transform) return;
        
        Display(data.Player, true, true, true, true); // Need to update this. These need to be set somewhere.
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
    
    public void DiplayMouseOverPathing(bool onTurn)
    {
        // for (int count = 0; count < GameManager.CellManager.GridWidth * GameManager.CellManager.GridHeight; count++)
        // {
        //     GameManager.CellManager.CellBattleControllerList[count].DisplayMouseOverPathing(Data.PathList[count]);
        // }
        // IsDisplayingMouseOverPathing = true;
    }

    public void StopDisplayingMouseOverPathing()
    {
        // for (int count = 0; count < GameManager.CellManager.GridWidth * GameManager.CellManager.GridHeight; count++)
        // {
        //     GameManager.CellManager.CellBattleControllerList[count].StopDisplayingMouseOverPathing();
        // }
        // IsDisplayingMouseOverPathing = false;
    }
    
    public virtual void Display(PlayerModel player, bool pathable, bool canPassThrough, bool inRange, bool canStop)
    {
        if (!canStop)
            return;
        
        HighlightAnimator.SetBool(Displaying, false); //To reset
        HighlightAnimator.SetBool(Displaying, true);
        HighlightAnimator.SetBool(Pathable, pathable);
        HighlightAnimator.SetBool(CanPassThrough, canPassThrough);
        HighlightAnimator.SetBool(InRange, inRange);
    }

    public virtual void StopDisplaying(PlayerModel player)
    {
        HighlightAnimator.SetBool(Displaying, false);
    }
    
    #endregion
}

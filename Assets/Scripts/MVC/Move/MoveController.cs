using System;
using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.Events;

public class MoveController : MonoBehaviour
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private UnitModel model;
    [SerializeField] private bool isMoving;

    #endregion
    #region Events

    [Header("Events")]
    [SerializeField] private UnityEvent eventIsMoving;
    [SerializeField] private EventPlayerModelAndTransformSO eventUnitSelected;
    [SerializeField] private EventPlayerModelAndTransformSO eventUnitDoubleSelected;
    [SerializeField] private EventPlayerModelAndTransformSO eventUnitDeselected;
    [SerializeField] private EventPlayerModelAndTransformSO eventCellMouseOn;

    #endregion
    #region Properties

    public UnitModel Model { get => model; set => model = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }

    #endregion
    #region Event Properties

    public UnityEvent EventIsMoving
    {
        get
        {
            if (eventIsMoving == null)
            {
                eventIsMoving = new UnityEvent();
            }
            return eventIsMoving;
        }

        set
        {
            eventIsMoving = value;
        }
    }

    public EventPlayerModelAndTransformSO UnitSelected
    {
        get => eventUnitSelected;
        set => eventUnitSelected = value;
    }

    public EventPlayerModelAndTransformSO UnitDoubleSelected
    {
        get => eventUnitDoubleSelected;
        set => eventUnitDoubleSelected = value;
    }

    public EventPlayerModelAndTransformSO UnitDeselected
    {
        get => eventUnitDeselected;
        set => eventUnitDeselected = value;
    }

    public EventPlayerModelAndTransformSO CellMouseOn
    {
        get => eventCellMouseOn;
        set => eventCellMouseOn = value;
    }

    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        UnitSelected.UnityEvent.AddListener(HandleUnitSelected);
        UnitDoubleSelected.UnityEvent.AddListener(HandleUnitDoubleSelected);
        UnitDeselected.UnityEvent.AddListener(HandleUnitDeselected);
        CellMouseOn.UnityEvent.AddListener(HandleCellMouseOn);
    }

    public void UnsubscribeFromEvents()
    {
        UnitSelected.UnityEvent.RemoveListener(HandleUnitSelected);
        UnitDoubleSelected.UnityEvent.RemoveListener(HandleUnitDoubleSelected);
        UnitDeselected.UnityEvent.RemoveListener(HandleUnitDeselected);
        CellMouseOn.UnityEvent.RemoveListener(HandleCellMouseOn);
    }

    #endregion
    #region Event Handlers

    public void HandleUnitSelected(PlayerAndTransformEventModel context)
    {
        if (IsMoving)
            return;
        
        if (context.Tf != transform)
            return;

        StartMoving();
    }

    public void HandleUnitDoubleSelected(PlayerAndTransformEventModel context)
    {
        if (!IsMoving)
            return;
        
        if (context.Tf != transform)
            return;
        
        //StopMoving();
    }
    
    public void HandleUnitDeselected(PlayerAndTransformEventModel context)
    {
        if (!IsMoving)
            return;
        
        if (context.Tf != transform)
            return;

        StopMoving();
    }

    public void HandleCellMouseOn(PlayerAndTransformEventModel context)
    {
        if (!IsMoving)
            return;

        Model.TransformPosition = context.Tf.position;
    }
    
    #endregion
    #region Monobehaviour

    public void Start()
    {
        Model = GetComponent<UnitBattleController>().Model;
        SubscribeToEvents();
    }

    public void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    
    #endregion
    #region Methods

    public void StartMoving()
    {
        IsMoving = true;
        EventIsMoving?.Invoke();
    }

    public void StopMoving()
    {
        IsMoving = false;
    }

    
    #endregion
}

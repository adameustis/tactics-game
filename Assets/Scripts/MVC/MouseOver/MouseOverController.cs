using System;
using System.Collections;
using System.Collections.Generic;
using MVC.EventData;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEvents;

public class MouseOverController : MonoBehaviour
{
    #region Fields
    #endregion
    #region Events
    
    [field: Header("Public Events")]
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOn;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOff;
    [field: Header("Local Events")]
    [SerializeField] private UnityEvent<PlayerAndTransformEventData> onMouseOn;
    [SerializeField] private UnityEvent<PlayerAndTransformEventData> onMouseOff;
    [SerializeField] private UnityEvent<MouseOverController> onDisabled;

    #endregion
    #region Properties

    #endregion
    #region Event Properties
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOn { get => eventInputMouseOn; private set => eventInputMouseOn = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOff { get => eventInputMouseOff; private set => eventInputMouseOff = value; }
    public UnityEvent<PlayerAndTransformEventData> OnMouseOn { get => onMouseOn; private set => onMouseOn = value; }
    public UnityEvent<PlayerAndTransformEventData> OnMouseOff { get => onMouseOff; private set => onMouseOff = value; }
    public UnityEvent<MouseOverController> OnDisabled { get => onDisabled; private set => onDisabled = value; }

    #endregion
    #region MonoBehaviour

    private void OnDisable()
    {
        OnDisabled.Invoke(this);
    }

    public void InvokeMouseOn(PlayerAndTransformEventData context)
    {
        EventInputMouseOn.UnityEvent.Invoke(context);
        OnMouseOn.Invoke(context);
    }
    
    public void InvokeMouseOff(PlayerAndTransformEventData context)
    {
        EventInputMouseOff.UnityEvent.Invoke(context);
        OnMouseOff.Invoke(context);
    }
    
    #endregion
    #region Methods
    #endregion
}

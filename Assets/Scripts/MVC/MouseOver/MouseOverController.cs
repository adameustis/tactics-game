using System;
using System.Collections;
using System.Collections.Generic;
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
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOff;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOn;
    [SerializeField] private UnityEvent<MouseOverController> onDisabled;

    #endregion
    #region Properties

    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOff { get => eventInputMouseOff; private set => eventInputMouseOff = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOn { get => eventInputMouseOn; private set => eventInputMouseOn = value; }
    public UnityEvent<MouseOverController> OnDisabled { get => onDisabled; private set => onDisabled = value; }

    #endregion
    #region MonoBehaviour

    private void OnDisable()
    {
        OnDisabled.Invoke(this);
    }

    #endregion
    #region Methods
    #endregion
}

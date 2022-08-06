using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseOverController : MonoBehaviour
{
    #region Fields
    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOff;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventInputMouseOn;

    #endregion
    #region Properties

    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOff { get => eventInputMouseOff; set => eventInputMouseOff = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventInputMouseOn { get => eventInputMouseOn; set => eventInputMouseOn = value; }

    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods
    #endregion
}

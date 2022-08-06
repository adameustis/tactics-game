using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventAbstractSO<EventType> : ScriptableObject where EventType : UnityEventBase
{
    #region Fields
    #endregion
    #region Events

    [SerializeField] private EventType unityEvent;

    #endregion
    #region Properties
    #endregion
    #region Event Properties

    public EventType UnityEvent { get => unityEvent; set => unityEvent = value; }

    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods

    public virtual void OnEnable()
    {
        UnityEvent.RemoveAllListeners();
    }

    #endregion
}

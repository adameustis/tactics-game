using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[System.Serializable]
public class TargetModel
{
    #region Fields

    [SerializeField] private bool isActive;

    #endregion
    #region Events

    [SerializeField] public UnityEvent eventIsActiveChanged;

    #endregion
    #region Properties

    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            if (isActive != value)
            {
                isActive = value;
                EventIsActiveChanged.Invoke();
            }
        }
    }

    #endregion
    #region Event Properties

    public virtual UnityEvent EventIsActiveChanged
    {
        get
        {
            if (eventIsActiveChanged == null)
            {
                eventIsActiveChanged = new UnityEvent();
            }
            return eventIsActiveChanged;
        }

        set
        {
            eventIsActiveChanged = value;
        }
    }

    #endregion
}

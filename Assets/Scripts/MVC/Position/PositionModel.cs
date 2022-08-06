using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PositionModel
{
    #region Fields

    [SerializeField] private Vector3 position;

    #endregion
    #region Events

    [SerializeField] public UnityEvent eventPositionChanged;

    #endregion
    #region Properties

    public Vector3 Position
    {
        get
        {
            return position;
        }

        set
        {
            if (position != value)
            {
                position = value;
                EventPositionChanged.Invoke();
            }
        }
    }

    #endregion
    #region Event Properties

    public virtual UnityEvent EventPositionChanged
    {
        get
        {
            if (eventPositionChanged == null)
            {
                eventPositionChanged = new UnityEvent();
            }
            return eventPositionChanged;
        }

        set
        {
            eventPositionChanged = value;
        }
    }

    #endregion
}

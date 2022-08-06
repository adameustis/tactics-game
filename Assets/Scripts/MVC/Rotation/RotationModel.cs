using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RotationModel
{
    #region Fields

    [SerializeField] private Quaternion rotation;

    #endregion
    #region Events

    [SerializeField] public UnityEvent eventRotationChanged;

    #endregion
    #region Properties

    public Quaternion Rotation
    {
        get
        {
            return rotation;
        }

        set
        {
            if (rotation != value)
            {
                rotation = value;
                EventRotationChanged.Invoke();
            }
        }
    }

    #endregion
    #region Event Properties

    public virtual UnityEvent EventRotationChanged
    {
        get
        {
            if (eventRotationChanged == null)
            {
                eventRotationChanged = new UnityEvent();
            }
            return eventRotationChanged;
        }

        set
        {
            eventRotationChanged = value;
        }
    }

    #endregion
}

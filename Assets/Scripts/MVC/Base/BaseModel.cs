using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class BaseModel
{
    #region Fields

    [Header("Base Fields")]
    protected Vector3 transformPosition;
    protected Quaternion transformRotation;
    protected TypeSO type;


    #endregion
    #region Events
    [Header("Base Events")]
    protected UnityEvent eventStateStart;
    protected UnityEvent eventStateStop;
    protected UnityEvent eventTransformPositionChanged;
    protected UnityEvent eventTransformRotationChanged;
    protected UnityEvent eventTypeChanged;


    #endregion
    #region Properties

    public virtual Vector3 TransformPosition
    {
        get
        {
            return transformPosition;
        }

        set
        {
            if (transformPosition != value)
            {
                transformPosition = value;
                EventTransformPositionChanged.Invoke();
            }
        }
    }
    public virtual Quaternion TransformRotation
    {
        get
        {
            return transformRotation;
        }

        set
        {
            if (transformRotation != value)
            {
                transformRotation = value;
                EventTransformRotationChanged.Invoke();
            }
        }
    }

    public virtual TypeSO Type
    {
        get
        {
            return type;
        }

        set
        {
            if (type != value)
            {
                type = value;
                EventTypeChanged.Invoke();
            }
        }
    }

    #endregion
    #region Event Properties

    public virtual UnityEvent EventStateStart
    {
        get
        {
            if (eventStateStart == null)
            {
                eventStateStart = new UnityEvent();
            }
            return eventStateStart;
        }

        set
        {
            eventStateStart = value;
        }
    }

    public virtual UnityEvent EventStateStop
    {
        get
        {
            if (eventStateStop == null)
            {
                eventStateStop = new UnityEvent();
            }
            return eventStateStop;
        }

        set
        {
            eventStateStop = value;
        }
    }

    public virtual UnityEvent EventTransformPositionChanged
    {
        get
        {
            if (eventTransformPositionChanged == null)
            {
                eventTransformPositionChanged = new UnityEvent();
            }
            return eventTransformPositionChanged;
        }

        set
        {
            eventTransformPositionChanged = value;
        }
    }

    public virtual UnityEvent EventTransformRotationChanged
    {
        get
        {
            if (eventTransformRotationChanged == null)
            {
                eventTransformRotationChanged = new UnityEvent();
            }
            return eventTransformRotationChanged;
        }

        set
        {
            eventTransformRotationChanged = value;
        }
    }

    public virtual UnityEvent EventTypeChanged
    {
        get
        {
            if (eventTypeChanged == null)
            {
                eventTypeChanged = new UnityEvent();
            }
            return eventTypeChanged;
        }

        set
        {
            eventTypeChanged = value;
        }
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class BaseView : MonoBehaviour
{
    #region Fields
    #endregion
    #region Events
    [Header("MonoBehaviour Events")]
    protected UnityEvent eventMonoBehaviourStart;
    protected UnityEvent eventMonoBehaviourOnDestroy;

    [Header("Transform Events")]
    protected UnityEvent eventTransformPositionChanged;
    protected UnityEvent eventTransformRotationChanged;

    [Header("Input Events")]
    protected UnityEvent eventInputBack;
    protected UnityEvent eventInputDown;
    protected UnityEvent eventInputLeft;
    protected UnityEvent eventInputOk;
    protected UnityEvent eventInputRight;
    protected UnityEvent eventInputUp;

    [Header("Mouse Over Events")]
    protected UnityEvent eventMouseOff;
    protected UnityEvent eventMouseOn;

    #endregion
    #region Properties

    public virtual Vector3 TransformPosition
    {
        get
        {
            return transform.position;
        }

        set
        {
            if (transform.position != value)
            {
                transform.position = value;
                EventTransformPositionChanged.Invoke();
            }
        }
    }

    public virtual Quaternion TransformRotation
    {
        get
        {
            return transform.rotation;
        }

        set
        {
            if (transform.rotation != value)
            {
                transform.rotation = value;
                eventTransformRotationChanged.Invoke();
            }
        }
    }

    #endregion
    #region Event Properties

    public virtual UnityEvent EventMonoBehaviourStart
    {
        get
        {
            if (eventMonoBehaviourStart == null)
            {
                eventMonoBehaviourStart = new UnityEvent();
            }
            return eventMonoBehaviourStart;
        }

        set
        {
            eventMonoBehaviourStart = value;
        }
    }

    public virtual UnityEvent EventMonoBehaviourOnDestroy
    {
        get
        {
            if (eventMonoBehaviourOnDestroy == null)
            {
                eventMonoBehaviourOnDestroy = new UnityEvent();
            }
            return eventMonoBehaviourOnDestroy;
        }

        set
        {
            eventMonoBehaviourOnDestroy = value;
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

    public virtual UnityEvent EventInputBack
    {
        get
        {
            if (eventInputBack == null)
            {
                eventInputBack = new UnityEvent();
            }
            return eventInputBack;
        }

        set
        {
            eventInputBack = value;
        }
    }

    public virtual UnityEvent EventInputDown
    {
        get
        {
            if (eventInputDown == null)
            {
                eventInputDown = new UnityEvent();
            }
            return eventInputDown;
        }

        set
        {
            eventInputDown = value;
        }
    }

    public virtual UnityEvent EventInputLeft
    {
        get
        {
            if (eventInputLeft == null)
            {
                eventInputLeft = new UnityEvent();
            }
            return eventInputLeft;
        }

        set
        {
            eventInputLeft = value;
        }
    }

    public virtual UnityEvent EventInputOk
    {
        get
        {
            if (eventInputOk == null)
            {
                eventInputOk = new UnityEvent();
            }
            return eventInputOk;
        }

        set
        {
            eventInputOk = value;
        }
    }

    public virtual UnityEvent EventInputRight
    {
        get
        {
            if (eventInputRight == null)
            {
                eventInputRight = new UnityEvent();
            }
            return eventInputRight;
        }

        set
        {
            eventInputRight = value;
        }
    }

    public virtual UnityEvent EventInputUp
    {
        get
        {
            if (eventInputUp == null)
            {
                eventInputUp = new UnityEvent();
            }
            return eventInputUp;
        }

        set
        {
            eventInputUp = value;
        }
    }

    public virtual UnityEvent EventMouseOff
    {
        get
        {
            if (eventMouseOff == null)
            {
                eventMouseOff = new UnityEvent();
            }
            return eventMouseOff;
        }

        set
        {
            eventMouseOff = value;
        }
    }

    public virtual UnityEvent EventMouseOn
    {
        get
        {
            if (eventMouseOn == null)
            {
                eventMouseOn = new UnityEvent();
            }
            return eventMouseOn;
        }

        set
        {
            eventMouseOn = value;
        }
    }

    #endregion
    #region MonoBehaviour

    public void Start()
    {
        EventMonoBehaviourStart.Invoke();
    }

    public void OnDestroy()
    {
        EventMonoBehaviourOnDestroy.Invoke();
    }

    #endregion
    #region Methods

    public abstract void Initialise();

    public virtual void InputBack()
    {
        EventInputBack.Invoke();
    }

    public virtual void InputDown()
    {
        EventInputDown.Invoke();
    }

    public virtual void InputLeft()
    {
        EventInputLeft.Invoke();
    }

    public virtual void InputOk()
    {
        EventInputOk.Invoke();
    }

    public virtual void InputRight()
    {
        EventInputRight.Invoke();
    }

    public virtual void InputUp()
    {
        EventInputUp.Invoke();
    }

    public void MouseOff()
    {
        EventMouseOff.Invoke();
    }

    public void MouseOn()
    {
        EventMouseOn.Invoke();
    }

    #endregion

}

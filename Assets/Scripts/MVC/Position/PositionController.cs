using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PositionController : MonoBehaviour
{
    #region Fields
    [SerializeField] private PositionModel model;
    #endregion
    #region Events

    [SerializeField] public UnityEvent eventPositionChanged;

    #endregion
    #region Properties

    public PositionModel Model
    {
        get
        {
            if (model == null)
            {
                model = new PositionModel();
            }
            return model;
        }

        set
        {
            model = value;
        }
    }

    public Vector3 Position
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
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        Model.EventPositionChanged.AddListener(HandleModelPositionChanged);
    }

    public void UnsubscribeFromEvents()
    {
        Model.EventPositionChanged.RemoveListener(HandleModelPositionChanged);
    }

    #endregion
    #region MonoBehaviour

    #endregion
    #region Methods

    public void Initialise(PositionModel setModel, PositionController setController)
    {
        Model = setModel;
        SubscribeToEvents();
        HandleViewPositionChanged();
    }

    public virtual void HandleModelPositionChanged()
    {
        transform.position = Model.Position;
    }

    public void HandleViewPositionChanged()
    {
        Model.Position = transform.position;
    }

    #endregion
}

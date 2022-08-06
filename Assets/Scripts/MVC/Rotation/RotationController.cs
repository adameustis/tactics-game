using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotationController : MonoBehaviour
{
    #region Fields
    [SerializeField] private RotationModel model;
    #endregion
    #region Events

    [SerializeField] public UnityEvent eventRotationChanged;

    #endregion
    #region Properties

    public RotationModel Model
    {
        get
        {
            if (model == null)
            {
                model = new RotationModel();
            }
            return model;
        }

        set
        {
            model = value;
        }
    }

    public virtual Quaternion Rotation
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
                eventRotationChanged.Invoke();
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
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        Model.EventRotationChanged.AddListener(HandleModelRotationChanged);
    }

    public void UnsubscribeFromEvents()
    {
        Model.EventRotationChanged.RemoveListener(HandleModelRotationChanged);
    }

    #endregion
    #region MonoBehaviour

    #endregion
    #region Methods

    public void Initialise(RotationModel setModel, RotationController setController)
    {
        Model = setModel;
        SubscribeToEvents();
        HandleViewRotationChanged();
    }

    public virtual void HandleModelRotationChanged()
    {
        transform.rotation = Model.Rotation;
    }

    public void HandleViewRotationChanged()
    {
        Model.Rotation = transform.rotation;
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseController<ModelType, ViewType> where ModelType : BaseModel where ViewType : BaseView
{
    #region Values

    [Header("Base Fields")]
    protected ModelType model;
    protected ViewType view;
    protected GameManagerSO gameManager;

    #endregion
    #region Properties

    public virtual ModelType Model { get => model; set => model = value; }
    public virtual ViewType View { get => view; set => view = value; }
    public virtual GameManagerSO GameManager { get => gameManager; set => gameManager = value; }

    #endregion
    #region Event Subscriptions

    public virtual void SubscribeToEvents() { }
    public virtual void UnsubscribeFromEvents() { }

    public virtual void SubscribeToBaseEvents()
    {
        Model.EventStateStart.AddListener(HandleModelStateStart);
        Model.EventStateStop.AddListener(HandleModelStateStop);
        Model.EventTransformPositionChanged.AddListener(HandleModelTransformPositionChanged);
        Model.EventTransformRotationChanged.AddListener(HandleModelTransformRotationChanged);
        Model.EventTypeChanged.AddListener(HandleModelTypeChanged);
        View.EventMonoBehaviourStart.AddListener(HandleViewMonobehaviourStart);
        View.EventMonoBehaviourOnDestroy.AddListener(HandleViewMonobehaviourOnDestroy);
        View.EventInputBack.AddListener(HandleViewInputBack);
        View.EventInputDown.AddListener(HandleViewInputDown);
        View.EventInputLeft.AddListener(HandleViewInputLeft);
        View.EventInputOk.AddListener(HandleViewInputOk);
        View.EventInputRight.AddListener(HandleViewInputRight);
        View.EventInputUp.AddListener(HandleViewInputUp);
        View.EventMouseOff.AddListener(HandleViewMouseOff);
        View.EventMouseOn.AddListener(HandleViewMouseOn);
        View.EventTransformPositionChanged.AddListener(HandleViewTransformPositionChanged);
        View.EventTransformRotationChanged.AddListener(HandleViewTransformRotationChanged);
    }

    public virtual void UnsubscribeFromBaseEvents()
    {
        Model.EventStateStart.RemoveListener(HandleModelStateStart);
        Model.EventStateStop.RemoveListener(HandleModelStateStop);
        Model.EventTransformPositionChanged.RemoveListener(HandleModelTransformPositionChanged);
        Model.EventTransformRotationChanged.RemoveListener(HandleModelTransformRotationChanged);
        Model.EventTypeChanged.RemoveListener(HandleModelTypeChanged);
        View.EventMonoBehaviourStart.RemoveListener(HandleViewMonobehaviourStart);
        View.EventMonoBehaviourOnDestroy.RemoveListener(HandleViewMonobehaviourOnDestroy);
        View.EventInputBack.RemoveListener(HandleViewInputBack);
        View.EventInputDown.RemoveListener(HandleViewInputDown);
        View.EventInputLeft.RemoveListener(HandleViewInputLeft);
        View.EventInputOk.RemoveListener(HandleViewInputOk);
        View.EventInputRight.RemoveListener(HandleViewInputRight);
        View.EventInputUp.RemoveListener(HandleViewInputUp);
        View.EventMouseOff.RemoveListener(HandleViewMouseOff);
        View.EventMouseOn.RemoveListener(HandleViewMouseOn);
        View.EventTransformPositionChanged.RemoveListener(HandleViewTransformPositionChanged);
        View.EventTransformRotationChanged.RemoveListener(HandleViewTransformRotationChanged);
    }

    #endregion
    #region Methods

    public virtual void Initialise(ModelType setModel, ViewType setView)
    {
        Model = setModel;
        View = setView;
        SubscribeToBaseEvents();
        SubscribeToEvents();
    }

    public virtual void HandleModelStateStart() { }
    public virtual void HandleModelStateStop() { }

    public virtual void HandleModelTransformPositionChanged()
    {
        View.TransformPosition = Model.TransformPosition;
    }

    public virtual void HandleModelTransformRotationChanged()
    {
        View.TransformRotation = Model.TransformRotation;
    }

    public virtual void HandleModelTypeChanged() { }
    public virtual void HandleViewMonobehaviourStart() { }
    public virtual void HandleViewMonobehaviourOnDestroy()
    {
        UnsubscribeFromBaseEvents();
        UnsubscribeFromEvents();
    }
    public virtual void HandleViewTransformPositionChanged()
    {
        Model.TransformPosition = View.TransformPosition;
    }
    public virtual void HandleViewTransformRotationChanged()
    {
        Model.TransformRotation = View.TransformRotation;
    }
    public virtual void HandleViewInputBack(){}
    public virtual void HandleViewInputDown(){}
    public virtual void HandleViewInputLeft(){}
    public virtual void HandleViewInputOk(){}
    public virtual void HandleViewInputRight(){}
    public virtual void HandleViewInputUp(){}
    public virtual void HandleViewMouseOff(){}
    public virtual void HandleViewMouseOn(){}

    #endregion
}

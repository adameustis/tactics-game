using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSelectionController : MonoBehaviour
{
    #region Values

    private SelectionController selectedObject;
    
    #endregion
    #region Events

    [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputSubmitEvent;
    [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputCancelEvent;
    [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> genericSelectedEvent;
    [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> genericDoubleSelectedEvent;
    [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> genericDeselectedEvent;

    #endregion
    #region Properties
    
    public SelectionController SelectedObject { get => selectedObject; set => selectedObject = value; }
    public bool HasSelection => SelectedObject != null;

    #endregion
    #region Event Properties

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputSubmitEvent
    {
        get => genericInputSubmitEvent;
        set => genericInputSubmitEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputCancelEvent
    {
        get => genericInputCancelEvent;
        set => genericInputCancelEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericDoubleSelectedEvent
    {
        get => genericDoubleSelectedEvent;
        set => genericDoubleSelectedEvent = value;
    }

    public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> GenericSelectedEvent { get => genericSelectedEvent; set => genericSelectedEvent = value; }
    public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> GenericDeselectedEvent { get => genericDeselectedEvent; set => genericDeselectedEvent = value; }


    #endregion
    #region Event Subscriptions
    
    public void SubscribeToEvents()
    {
        genericInputSubmitEvent.UnityEvent.AddListener(SubmitEventHandler);
        GenericInputCancelEvent.UnityEvent.AddListener(SubmitEventHandler);
    }

    public void UnsubscribeFromEvents()
    {
        genericInputSubmitEvent.UnityEvent.RemoveListener(SubmitEventHandler);
        GenericInputCancelEvent.UnityEvent.RemoveListener(SubmitEventHandler);
    }
    
    #endregion
    #region Event Handlers
    
    public void CancelEventHandler(PlayerAndTransformEventModel eventModel)
    {
        Deselect(eventModel.Player);
    }

    public void SubmitEventHandler(PlayerAndTransformEventModel eventModel)
    {
        Select(eventModel);
    }
    
    #endregion
    #region MonoBehaviour
    
    public void Start()
    {
        Initialise();
    }

    public void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    
    #endregion
    #region Methods

    public void Initialise()
    {
        SubscribeToEvents();
    }
    
    public void Select(PlayerAndTransformEventModel eventModel)
    {
        SelectionController newSelection = eventModel.Tf.GetComponent<SelectionController>();

        if (newSelection == null)
            return;

        if (SelectedObject == newSelection)
        {
            DoubleSelect(eventModel);
            return;
        }

        if (HasSelection)
            Deselect(eventModel.Player);
        
        newSelection.Select(eventModel.Player);
        GenericSelectedEvent.UnityEvent?.Invoke(eventModel);
        SelectedObject = newSelection;


    }

    public void DoubleSelect(PlayerAndTransformEventModel eventModel)
    {
        SelectionController newSelection = eventModel.Tf.GetComponent<SelectionController>();

        if (newSelection == null)
            return;
        
        newSelection.DoubleSelect(eventModel.Player);
        GenericDoubleSelectedEvent.UnityEvent?.Invoke(eventModel);
    }
    
    public void Deselect(PlayerModel player)
    {
        if (SelectedObject == null)
            return;
        
        SelectedObject.Deselect(player);
        GenericDeselectedEvent.UnityEvent?.Invoke(new PlayerAndTransformEventModel(player, SelectedObject.transform));
        SelectedObject = null;
    }    


    #endregion
}

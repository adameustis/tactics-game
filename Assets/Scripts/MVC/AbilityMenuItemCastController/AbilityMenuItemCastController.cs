using System.Collections;
using System.Collections.Generic;
using Interfaces;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class AbilityMenuItemCastController  : MonoBehaviour
{
    #region Fields
    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventDeselect;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> eventSelect;

    #endregion
    #region Properties
    #endregion
    #region Event Properties
    
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventDeselect { get => eventDeselect; set => eventDeselect = value; }
    public EventAbstractSO<UnityEventPlayerModelAndTransform> EventSelect { get => eventSelect; set => eventSelect = value; }
    
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        EventDeselect.UnityEvent.AddListener(SelectEventHandler);
        EventSelect.UnityEvent.AddListener(DeselectEventHandler);
    }

    public void UnsubscribeFromEvents()
    {
        EventDeselect.UnityEvent.RemoveListener(SelectEventHandler);
        EventSelect.UnityEvent.RemoveListener(DeselectEventHandler);
    }

    #endregion
    #region Event Handlers
    
    public void SelectEventHandler(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform) return;
        
        Cast(eventModel);
    }

    public void DeselectEventHandler(PlayerAndTransformEventModel eventModel)
    {
        if (eventModel.Tf != transform) return;
        
        StopCast(eventModel);
    }
    
    #endregion 
    #region MonoBehaviour

    public void Start()
    {
        SubscribeToEvents();
    }

    public void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    #endregion
    #region Methods

    public void Initialise()
    {
    }

    public void Cast(PlayerAndTransformEventModel eventModel)
    {
        EventAbstractSO<UnityEventPlayerModelAndTransform> castEvent =
            transform.GetComponent<AbilityController>().Model.Ability.CastEvent;
        castEvent.UnityEvent?.Invoke(eventModel);
    }
    
    public void StopCast(PlayerAndTransformEventModel eventModel)
    {
        EventAbstractSO<UnityEventPlayerModelAndTransform> stopCastEvent =
            transform.GetComponent<AbilityController>().Model.Ability.StopCastEvent;
        stopCastEvent.UnityEvent?.Invoke(eventModel);
    }
    
    #endregion
}

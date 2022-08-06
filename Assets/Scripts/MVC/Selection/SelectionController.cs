using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SelectionController : MonoBehaviour
{
    #region Values
    
    [SerializeField] protected SelectionModel model;
    
    #endregion
    #region Events
    
    [FormerlySerializedAs("eventSelected")] [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> selectedEvent;
    [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> doubleSelectedEvent;
    [FormerlySerializedAs("eventDeselected")] [SerializeField] protected EventAbstractSO<UnityEventPlayerModelAndTransform> deselectedEvent;

    #endregion
    #region Properties
    
    public SelectionModel Model { get => model; set => model = value; }
    
    #endregion
    #region Event Properties
    
    public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> SelectedEvent { get => selectedEvent; set => selectedEvent = value; }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> DoubleSelectedEvent
    {
        get => doubleSelectedEvent;
        set => doubleSelectedEvent = value;
    }

    public virtual EventAbstractSO<UnityEventPlayerModelAndTransform> DeselectedEvent { get => deselectedEvent; set => deselectedEvent = value; }


    #endregion
    #region Event Subscriptions
    #endregion
    #region Event Handlers
    #endregion
    #region MonoBehaviour
    
    public void Start()
    {
        Initialise(Model);
    }

    #endregion
    #region Methods

    public void Initialise(SelectionModel setModel)
    {
        Model = setModel;
    }
    
    public void DisplaySelectionPathing(bool onTurn)
    {
        // for (int count = 0; count < GameManager.CellManager.GridWidth * GameManager.CellManager.GridHeight; count++)
        // {
        //     GameManager.CellManager.CellBattleControllerList[count].DisplaySelectionPathing(Model.PathList[count], onTurn);
        // }
        // IsDisplayingSelectionPathing = true;
    }

    public void StopDisplayingSelectionPathing()
    {
        // for (int count = 0; count < GameManager.CellManager.GridWidth * GameManager.CellManager.GridHeight; count++)
        // {
        //     GameManager.CellManager.CellBattleControllerList[count].StopDisplayingSelectionPathing();
        // }
        // IsDisplayingSelectionPathing = false;
    }
    
    public void Select(PlayerModel player)
    {
        if (Model.IsSelected) return;
        Model.IsSelected = true;
        SelectedEvent.UnityEvent?.Invoke(new PlayerAndTransformEventModel(player, transform));
    }

    public void DoubleSelect(PlayerModel player)
    {
        if (!Model.IsSelected) return;
        DoubleSelectedEvent.UnityEvent?.Invoke(new PlayerAndTransformEventModel(player, transform));
    }
    
    public void Deselect(PlayerModel player)
    {
        if (!Model.IsSelected) return;
        Model.IsSelected = false;
        DeselectedEvent.UnityEvent?.Invoke(new PlayerAndTransformEventModel(player, transform));
    }

    #endregion
}

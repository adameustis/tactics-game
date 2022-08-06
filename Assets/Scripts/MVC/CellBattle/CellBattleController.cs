using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class CellBattleController : MonoBehaviour
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private CellModel model;
    [SerializeField] private GameManagerSO gameManager;

    #endregion
    #region Events
    #endregion
    #region Properties

    public CellModel Model { get => model; set => model = value; }
    
    public GameManagerSO GameManager { get => gameManager; set => gameManager = value; }

    #endregion
    #region Event Properties
    #endregion
    #region MonoBehaviour
    public virtual void Start()
    {
        Initialise(Model);
    }
    public void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
    
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        Model.EventTransformPositionChanged.AddListener(HandleTransformPositionChanged);
        Model.EventCellAdjacentCellAdded.AddListener(HandleCellAdjacentCellAdded);
        Model.EventCellAdjacentCellRemoved.AddListener(HandleCellAdjacentCellRemoved);
        Model.EventCellGridPositionXChanged.AddListener(HandleCellGridPositionXChanged);
        Model.EventCellGridPositionYChanged.AddListener(HandleCellGridPositionYChanged);
        Model.EventCellHasResidentUnitChanged.AddListener(HandleCellHasResidentUnitChanged);
        Model.EventCellIconChanged.AddListener(HandleCellIconChanged);
        Model.EventCellIsAirDestinationChanged.AddListener(HandleCellIsAirDestinationChanged);
        Model.EventCellIsAirTraversableChanged.AddListener(HandleCellIsAirTraversableChanged);
        Model.EventCellIsLandDestinationChanged.AddListener(HandleCellIsLandDestinationChanged);
        Model.EventCellIsLandTraversableChanged.AddListener(HandleCellIsLandTraversableChanged);
        Model.EventCellNameChanged.AddListener(HandleCellNameChanged);
        Model.EventCellResidentUnitChanged.AddListener(HandleCellResidentUnitChanged);
    }

    public void UnsubscribeFromEvents()
    {
        Model.EventTransformPositionChanged.RemoveListener(HandleTransformPositionChanged);
        Model.EventCellAdjacentCellAdded.RemoveListener(HandleCellAdjacentCellAdded);
        Model.EventCellAdjacentCellRemoved.RemoveListener(HandleCellAdjacentCellRemoved);
        Model.EventCellGridPositionXChanged.RemoveListener(HandleCellGridPositionXChanged);
        Model.EventCellGridPositionYChanged.RemoveListener(HandleCellGridPositionYChanged);
        Model.EventCellHasResidentUnitChanged.RemoveListener(HandleCellHasResidentUnitChanged);
        Model.EventCellIconChanged.RemoveListener(HandleCellIconChanged);
        Model.EventCellIsAirDestinationChanged.RemoveListener(HandleCellIsAirDestinationChanged);
        Model.EventCellIsAirTraversableChanged.RemoveListener(HandleCellIsAirTraversableChanged);
        Model.EventCellIsLandDestinationChanged.RemoveListener(HandleCellIsLandDestinationChanged);
        Model.EventCellIsLandTraversableChanged.RemoveListener(HandleCellIsLandTraversableChanged);
        Model.EventCellNameChanged.RemoveListener(HandleCellNameChanged);
        Model.EventCellResidentUnitChanged.RemoveListener(HandleCellResidentUnitChanged);
    }

    #endregion
    #region Event Handlers

    public void HandleTransformPositionChanged()
    {
        transform.position = Model.TransformPosition;
    }
    
    public void HandleCellNameChanged()
    {

    }

    public void HandleCellIconChanged()
    {

    }

    public void HandleCellGridPositionXChanged()
    {

    }

    public void HandleCellGridPositionYChanged()
    {

    }

    public void HandleCellIsLandTraversableChanged()
    {

    }

    public void HandleCellIsAirTraversableChanged()
    {

    }

    public void HandleCellIsLandDestinationChanged()
    {

    }

    public void HandleCellIsAirDestinationChanged()
    {

    }

    public void HandleCellHasResidentUnitChanged()
    {

    }

    public void HandleCellResidentUnitChanged()
    {

    }

    public void HandleCellAdjacentCellAdded(CellModel cell)
    {

    }

    public void HandleCellAdjacentCellRemoved(CellModel cell)
    {

    }

    #endregion
    #region Methods

    public void Initialise(CellModel setModel)
    {
        Model = setModel;
        Model.TransformPosition = transform.position;
        GameManager.CellManager.SetCellModel(Model, Model.CellGridPositionX, Model.CellGridPositionY);
        GameManager.CellManager.SetCellBattleController(this, Model.CellGridPositionX, Model.CellGridPositionY);
        SubscribeToEvents();
    }

    #endregion

}

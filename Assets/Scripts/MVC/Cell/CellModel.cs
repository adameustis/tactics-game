using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CellModel
{
    #region Delegates
    #endregion
    #region Fields

    // Cell
    [SerializeField] private Vector3 transformPosition;
    [SerializeField] private string cellName;
    [SerializeField] private Sprite cellIcon;
    [SerializeField] private string cellDescription;
    [SerializeField] private int cellGridPositionX;
    [SerializeField] private int cellGridPositionY;
    [SerializeField] private bool cellIsLandTraversable;
    [SerializeField] private bool cellIsAirTraversable;
    [SerializeField] private bool cellIsLandDestination;
    [SerializeField] private bool cellIsAirDestination;
    [SerializeField] private bool cellHasResidentUnit;
    [System.NonSerialized] private UnitModel cellResidentUnit;
    [System.NonSerialized] private List<CellModel> cellAdjacentCells;

    #endregion
    #region Events

    private UnityEvent eventTransformPositionChanged;
    private UnityEvent eventCellNameChanged;
    private UnityEvent eventCellDescriptionChanged;
    private UnityEvent eventCellIconChanged;
    private UnityEvent eventCellGridPositionXChanged;
    private UnityEvent eventCellGridPositionYChanged;
    private UnityEvent eventCellIsLandTraversableChanged;
    private UnityEvent eventCellIsAirTraversableChanged;
    private UnityEvent eventCellIsLandDestinationChanged;
    private UnityEvent eventCellIsAirDestinationChanged;
    private UnityEvent eventCellHasResidentUnitChanged;
    private UnityEvent eventCellResidentUnitChanged;
    private UnityEventCellModel eventCellAdjacentCellAdded;
    private UnityEventCellModel eventCellAdjacentCellRemoved;

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
    public string CellName { get => cellName; set => cellName = value; }

    public string CellDescription { get => cellDescription; set => cellDescription = value; }
    
    public Sprite CellIcon
    {
        get
        {
            return cellIcon;
        }

        set
        {
            if (cellIcon != value)
            {
                cellIcon = value;
                EventCellIconChanged.Invoke();
            }
        }
    }

    public int CellGridPositionX
    {
        get
        {
            return cellGridPositionX;
        }

        set
        {
            if (cellGridPositionX != value)
            {
                cellGridPositionX = value;
                EventCellGridPositionXChanged.Invoke();
            }
        }
    }

    public int CellGridPositionY
    {
        get
        {
            return cellGridPositionY;
        }

        set
        {
            if (cellGridPositionY != value)
            {
                cellGridPositionY = value;
                EventCellGridPositionYChanged.Invoke();
            }
        }
    }

    public bool CellIsLandTraversable
    {
        get
        {
            return cellIsLandTraversable;
        }

        set
        {
            if (cellIsLandTraversable != value)
            {
                cellIsLandTraversable = value;
                EventCellIsLandTraversableChanged.Invoke();
            }
        }
    }

    public bool CellIsAirTraversable
    {
        get
        {
            return cellIsAirTraversable;
        }

        set
        {
            if (cellIsAirTraversable != value)
            {
                cellIsAirTraversable = value;
                EventCellIsAirTraversableChanged.Invoke();
            }
        }
    }

    public bool CellIsLandDestination
    {
        get
        {
            return cellIsLandDestination;
        }

        set
        {
            if (cellIsLandDestination != value)
            {
                cellIsLandDestination = value;
                EventCellIsLandDestinationChanged.Invoke();
            }
        }
    }

    public bool CellIsAirDestination
    {
        get
        {
            return cellIsAirDestination;
        }

        set
        {
            if (cellIsAirDestination != value)
            {
                cellIsAirDestination = value;
                EventCellIsAirDestinationChanged.Invoke();
            }
        }
    }

    public bool CellHasResidentUnit
    {
        get
        {
            return cellHasResidentUnit;
        }

        set
        {
            if (cellHasResidentUnit != value)
            {
                cellHasResidentUnit = value;
                EventCellHasResidentUnitChanged.Invoke();
            }
        }
    }

    public UnitModel CellResidentUnit
    {
        get
        {
            return cellResidentUnit;
        }

        set
        {
            if (cellResidentUnit != value)
            {
                if (value == null)
                {
                    cellResidentUnit = value;
                    CellHasResidentUnit = false;
                }
                else if (cellResidentUnit == null)
                {
                    cellResidentUnit = value;
                    CellHasResidentUnit = true;
                }
                else
                {
                    cellResidentUnit = value;
                    EventCellResidentUnitChanged.Invoke();
                }
            }
        }
    }

    public List<CellModel> CellAdjacentCells
    {
        get
        {
            if (cellAdjacentCells == null)
            {
                cellAdjacentCells = new List<CellModel>();
            }
            return cellAdjacentCells;
        }

        private set // Private because if events are put here they won't fire for .Add() method etc.
        {
            cellAdjacentCells = value;
        }
    }
    
    #endregion
    #region Event Properties
    public UnityEvent EventTransformPositionChanged
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
    public UnityEvent EventCellNameChanged
    {
        get
        {
            if (eventCellNameChanged == null)
            {
                eventCellNameChanged = new UnityEvent();
            }
            return eventCellNameChanged;
        }

        set
        {
            eventCellNameChanged = value;
        }
    }

    public UnityEvent EventCellDescriptionChanged
    {
        get
        {
            if (eventCellDescriptionChanged == null)
            {
                eventCellDescriptionChanged = new UnityEvent();
            }
            return eventCellDescriptionChanged;
        }

        set
        {
            eventCellDescriptionChanged = value;
        }
    }
    public UnityEvent EventCellIconChanged
    {
        get
        {
            if (eventCellIconChanged == null)
            {
                eventCellIconChanged = new UnityEvent();
            }
            return eventCellIconChanged;
        }

        set
        {
            eventCellIconChanged = value;
        }
    }

    public UnityEvent EventCellGridPositionXChanged
    {
        get
        {
            if (eventCellGridPositionXChanged == null)
            {
                eventCellGridPositionXChanged = new UnityEvent();
            }
            return eventCellGridPositionXChanged;
        }

        set
        {
            eventCellGridPositionXChanged = value;
        }
    }

    public UnityEvent EventCellGridPositionYChanged
    {
        get
        {
            if (eventCellGridPositionYChanged == null)
            {
                eventCellGridPositionYChanged = new UnityEvent();
            }
            return eventCellGridPositionYChanged;
        }

        set
        {
            eventCellGridPositionYChanged = value;
        }
    }

    public UnityEvent EventCellIsLandTraversableChanged
    {
        get
        {
            if (eventCellIsLandTraversableChanged == null)
            {
                eventCellIsLandTraversableChanged = new UnityEvent();
            }
            return eventCellIsLandTraversableChanged;
        }

        set
        {
            eventCellIsLandTraversableChanged = value;
        }
    }

    public UnityEvent EventCellIsAirTraversableChanged
    {
        get
        {
            if (eventCellIsAirTraversableChanged == null)
            {
                eventCellIsAirTraversableChanged = new UnityEvent();
            }
            return eventCellIsAirTraversableChanged;
        }

        set
        {
            eventCellIsAirTraversableChanged = value;
        }
    }

    public UnityEvent EventCellIsLandDestinationChanged
    {
        get
        {
            if (eventCellIsLandDestinationChanged == null)
            {
                eventCellIsLandDestinationChanged = new UnityEvent();
            }
            return eventCellIsLandDestinationChanged;
        }

        set
        {
            eventCellIsLandDestinationChanged = value;
        }
    }

    public UnityEvent EventCellIsAirDestinationChanged
    {
        get
        {
            if (eventCellIsAirDestinationChanged == null)
            {
                eventCellIsAirDestinationChanged = new UnityEvent();
            }
            return eventCellIsAirDestinationChanged;
        }

        set
        {
            eventCellIsAirDestinationChanged = value;
        }
    }

    public UnityEvent EventCellHasResidentUnitChanged
    {
        get
        {
            if (eventCellHasResidentUnitChanged == null)
            {
                eventCellHasResidentUnitChanged = new UnityEvent();
            }
            return eventCellHasResidentUnitChanged;
        }

        set
        {
            eventCellHasResidentUnitChanged = value;
        }
    }

    public UnityEvent EventCellResidentUnitChanged
    {
        get
        {
            if (eventCellResidentUnitChanged == null)
            {
                eventCellResidentUnitChanged = new UnityEvent();
            }
            return eventCellResidentUnitChanged;
        }

        set
        {
            eventCellResidentUnitChanged = value;
        }
    }

    public UnityEventCellModel EventCellAdjacentCellAdded
    {
        get
        {
            if (eventCellAdjacentCellAdded == null)
            {
                eventCellAdjacentCellAdded = new UnityEventCellModel();
            }
            return eventCellAdjacentCellAdded;
        }

        set
        {
            eventCellAdjacentCellAdded = value;
        }
    }

    public UnityEventCellModel EventCellAdjacentCellRemoved
    {
        get
        {
            if (eventCellAdjacentCellRemoved == null)
            {
                eventCellAdjacentCellRemoved = new UnityEventCellModel();
            }
            return eventCellAdjacentCellRemoved;
        }

        set
        {
            eventCellAdjacentCellRemoved = value;
        }
    }

    

    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public void AddAdjacentCell(CellModel cell)
    {
        if (cell == null)
        {
            return;
        }
        CellAdjacentCells.Add(cell);
        EventCellAdjacentCellAdded.Invoke(cell);
    }

    public void RemoveAdjacentCell(CellModel cell)
    {
        if (cell == null)
        {
            return;
        }
        if (!CellAdjacentCells.Contains(cell))
        {
            return;
        }
        CellAdjacentCells.Remove(cell);
        EventCellAdjacentCellRemoved.Invoke(cell);
    }

    #endregion
}

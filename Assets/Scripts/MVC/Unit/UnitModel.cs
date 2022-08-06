using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnitModel
{
    #region Delegates
    #endregion
    #region Fields
    [SerializeField] private Vector3 transformPosition;
    [SerializeField] private int unitNumber;
    [SerializeField] private string unitName;
    [SerializeField] private Sprite unitIcon;
    [SerializeField] private int unitHP;
    [SerializeField] private int unitMaxHP;

    [SerializeField] private List<AbilityModel> unitAbilities;
    [SerializeField] private List<StatusModel> unitStatuses;

    [SerializeField] private bool unitCanLandTraverse;
    [SerializeField] private bool unitCanAirTraverse;
    [SerializeField] private bool unitCanStopOnLand;
    [SerializeField] private bool unitCanStopInAir;
    [SerializeField] private bool unitHasCellResidence = new bool();
    [SerializeField] private CellModel unitCellResidence;

    [SerializeField] private bool unitOnTurn;
    [SerializeField] private int unitTurnWaitValue;
    [SerializeField] private int unitEnergyUsed;

    [SerializeField] private bool hasCurrentDestination;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Queue<PathModel> movePathQueue;
    [SerializeField] private int movePathLength;
    [SerializeField] private PathModel moveCurrentPath;
    [SerializeField] private PathModel[] pathList;

    #endregion
    #region Events

    [SerializeField] private UnityEvent eventTransformPositionChanged;
    [SerializeField] private UnityEvent eventUnitNumberChanged;
    [SerializeField] private UnityEvent eventUnitNameChanged;
    [SerializeField] private UnityEvent eventUnitIconChanged;
    [SerializeField] private UnityEvent eventUnitHPChanged;
    [SerializeField] private UnityEvent eventUnitMaxHPChanged;
    [SerializeField] private UnityEventAbilityModel eventUnitAbilityAdded;
    [SerializeField] private UnityEventAbilityModel eventUnitAbilityRemoved;
    [SerializeField] private UnityEventStatusModel eventUnitStatusAdded;
    [SerializeField] private UnityEventStatusModel eventUnitStatusRemoved;
    [SerializeField] private UnityEvent eventUnitCanLandTraverseChanged;
    [SerializeField] private UnityEvent eventUnitCanAirTraverseChanged;
    [SerializeField] private UnityEvent eventUnitCanStopOnLandChanged;
    [SerializeField] private UnityEvent eventUnitCanStopInAirChanged;
    [SerializeField] private UnityEvent eventUnitHasCellResidenceChanged;
    [SerializeField] private UnityEvent eventUnitCellResidenceChanged;
    [SerializeField] private UnityEvent eventUnitOnTurnChanged;
    [SerializeField] private UnityEvent eventUnitTurnWaitValueChanged;
    [SerializeField] private UnityEvent eventUnitEnergyUsedChanged;

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
    public int UnitNumber
    {
        get
        {
            return unitNumber;
        }

        set
        {
            if (unitNumber != value)
            {
                unitNumber = value;
                EventUnitNumberChanged.Invoke();
            }
        }
    }

    public string UnitName
    {
        get
        {
            return unitName;
        }

        set
        {
            if (unitName != value)
            {
                unitName = value;
                EventUnitNameChanged.Invoke();
            }
        }
    }

    public Sprite UnitIcon
    {
        get
        {
            return unitIcon;
        }

        set
        {
            if (unitIcon != value)
            {
                unitIcon = value;
                EventUnitIconChanged.Invoke();
            }
        }
    }

    public int UnitHP
    {
        get
        {
            return unitHP;
        }

        set
        {
            if (unitHP != value)
            {
                if(value < 0)
                {
                    unitHP = 0;
                }
                else
                {
                    unitHP = value;
                }
                EventUnitHPChanged.Invoke();
            }
        }
    }

    public int UnitMaxHP
    {
        get
        {
            return unitMaxHP;
        }

        set
        {
            if (unitMaxHP != value)
            {
                if (value < 0)
                {
                    unitMaxHP = 0;
                }
                else
                {
                    unitMaxHP = value;
                }
                EventUnitMaxHPChanged.Invoke();
            }
        }
    }

    public List<AbilityModel> UnitAbilities
    {
        get
        {
            return unitAbilities;
        }

        private set // Private because if events are put here they won't fire for .Add() method etc.
        {
            unitAbilities = value;
        }
    }

    public List<StatusModel> UnitStatuses
    {
        get
        {
            return unitStatuses;
        }

        private set // Private because if events are put here they won't fire for .Add() method etc.
        {
            unitStatuses = value;
        }
    }

    public bool UnitCanLandTraverse
    {
        get
        {
            return unitCanLandTraverse;
        }

        set
        {
            if (unitCanLandTraverse != value)
            {
                unitCanLandTraverse = value;
                EventUnitCanLandTraverseChanged.Invoke();
            }
        }
    }

    public bool UnitCanAirTraverse
    {
        get
        {
            return unitCanAirTraverse;
        }

        set
        {
            if (unitCanAirTraverse != value)
            {
                unitCanAirTraverse = value;
                EventUnitCanAirTraverseChanged.Invoke();
            }
        }
    }

    public bool UnitCanStopOnLand
    {
        get
        {
            return unitCanStopOnLand;
        }

        set
        {
            if (unitCanStopOnLand != value)
            {
                unitCanStopOnLand = value;
                EventUnitCanStopOnLandChanged.Invoke();
            }
        }
    }

    public bool UnitCanStopInAir
    {
        get
        {
            return unitCanStopInAir;
        }

        set
        {
            if (unitCanStopInAir != value)
            {
                unitCanStopInAir = value;
                EventUnitCanStopInAirChanged.Invoke();
            }
        }
    }

    public bool UnitHasCellResidence
    {
        get
        {
            return unitHasCellResidence;
        }

        set
        {
            if (unitHasCellResidence != value)
            {
                unitHasCellResidence = value;
                EventUnitHasCellResidenceChanged.Invoke();
            }
        }
    }

    public CellModel UnitCellResidence
    {
        get
        {
            return unitCellResidence;
        }

        set
        {
            if (unitCellResidence != value)
            {
                if (value == null)
                {
                    unitCellResidence = value;
                    UnitHasCellResidence = false;
                }
                else if(unitCellResidence == null)
                {
                    unitCellResidence = value;
                    UnitHasCellResidence = true;
                }
                else
                {
                    unitCellResidence = value;
                    EventUnitCellResidenceChanged.Invoke();
                }
            }
        }
    }

    public bool UnitOnTurn
    {
        get
        {
            return unitOnTurn;
        }

        set
        {
            if (unitOnTurn != value)
            {
                unitOnTurn = value;
                EventUnitOnTurnChanged.Invoke();
            }
        }
    }

    public int UnitTurnWaitValue
    {
        get
        {
            return unitTurnWaitValue;
        }

        set
        {
            if (unitTurnWaitValue != value)
            {
                unitTurnWaitValue = value;
                if (unitTurnWaitValue < 0)
                {
                    unitTurnWaitValue = 0;
                }
                EventUnitTurnWaitValueChanged.Invoke();
            }
        }
    }

    public int UnitEnergyUsed
    {
        get
        {
            return unitEnergyUsed;
        }

        set
        {
            if (unitEnergyUsed != value)
            {
                unitEnergyUsed = value;
                EventUnitEnergyUsedChanged.Invoke();
            }
        }
    }

    public bool HasCurrentDestination { get => hasCurrentDestination; set => hasCurrentDestination = value; }
    public float Speed { get => speed; set => speed = value; }
    public Queue<PathModel> MovePathQueue
    {
        get
        {
            return movePathQueue;
        }

        set
        {
            if (value != null)
            {
                movePathQueue = new Queue<PathModel>(value);
            }
            else
            {
                movePathQueue = null;
            }
        }
    }
    public PathModel MoveCurrentPath { get => moveCurrentPath; set => moveCurrentPath = value; }

    public PathModel[] PathList { get => pathList; set => pathList = value; }

    #endregion
    #region Events Properties

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
    public UnityEvent EventUnitNumberChanged
    {
        get
        {
            if (eventUnitNumberChanged == null)
            {
                eventUnitNumberChanged = new UnityEvent();
            }
            return eventUnitNumberChanged;
        }

        set
        {
            eventUnitNumberChanged = value;
        }
    }

    public UnityEvent EventUnitNameChanged
    {
        get
        {
            if (eventUnitNameChanged == null)
            {
                eventUnitNameChanged = new UnityEvent();
            }
            return eventUnitNameChanged;
        }

        set
        {
            eventUnitNameChanged = value;
        }
    }

    public UnityEvent EventUnitIconChanged
    {
        get
        {
            if (eventUnitIconChanged == null)
            {
                eventUnitIconChanged = new UnityEvent();
            }
            return eventUnitIconChanged;
        }

        set
        {
            eventUnitIconChanged = value;
        }
    }

    public UnityEvent EventUnitHPChanged
    {
        get
        {
            if (eventUnitHPChanged == null)
            {
                eventUnitHPChanged = new UnityEvent();
            }
            return eventUnitHPChanged;
        }

        set
        {
            eventUnitHPChanged = value;
        }
    }

    public UnityEvent EventUnitMaxHPChanged
    {
        get
        {
            if (eventUnitMaxHPChanged == null)
            {
                eventUnitMaxHPChanged = new UnityEvent();
            }
            return eventUnitMaxHPChanged;
        }

        set
        {
            eventUnitMaxHPChanged = value;
        }
    }

    public UnityEventAbilityModel EventUnitAbilityAdded
    {
        get
        {
            if (eventUnitAbilityAdded == null)
            {
                eventUnitAbilityAdded = new UnityEventAbilityModel();
            }
            return eventUnitAbilityAdded;
        }

        set
        {
            eventUnitAbilityAdded = value;
        }
    }

    public UnityEventAbilityModel EventUnitAbilityRemoved
    {
        get
        {
            if (eventUnitAbilityRemoved == null)
            {
                eventUnitAbilityRemoved = new UnityEventAbilityModel();
            }
            return eventUnitAbilityRemoved;
        }

        set
        {
            eventUnitAbilityRemoved = value;
        }
    }

    public UnityEventStatusModel EventUnitStatusAdded
    {
        get
        {
            if (eventUnitStatusAdded == null)
            {
                eventUnitStatusAdded = new UnityEventStatusModel();
            }
            return eventUnitStatusAdded;
        }

        set
        {
            eventUnitStatusAdded = value;
        }
    }

    public UnityEventStatusModel EventUnitStatusRemoved
    {
        get
        {
            if (eventUnitStatusRemoved == null)
            {
                eventUnitStatusRemoved = new UnityEventStatusModel();
            }
            return eventUnitStatusRemoved;
        }

        set
        {
            eventUnitStatusRemoved = value;
        }
    }

    public UnityEvent EventUnitCanLandTraverseChanged
    {
        get
        {
            if (eventUnitCanLandTraverseChanged == null)
            {
                eventUnitCanLandTraverseChanged = new UnityEvent();
            }
            return eventUnitCanLandTraverseChanged;
        }

        set
        {
            eventUnitCanLandTraverseChanged = value;
        }
    }

    public UnityEvent EventUnitCanAirTraverseChanged
    {
        get
        {
            if (eventUnitCanAirTraverseChanged == null)
            {
                eventUnitCanAirTraverseChanged = new UnityEvent();
            }
            return eventUnitCanAirTraverseChanged;
        }

        set
        {
            eventUnitCanAirTraverseChanged = value;
        }
    }

    public UnityEvent EventUnitCanStopOnLandChanged
    {
        get
        {
            if (eventUnitCanStopOnLandChanged == null)
            {
                eventUnitCanStopOnLandChanged = new UnityEvent();
            }
            return eventUnitCanStopOnLandChanged;
        }

        set
        {
            eventUnitCanStopOnLandChanged = value;
        }
    }

    public UnityEvent EventUnitCanStopInAirChanged
    {
        get
        {
            if (eventUnitCanStopInAirChanged == null)
            {
                eventUnitCanStopInAirChanged = new UnityEvent();
            }
            return eventUnitCanStopInAirChanged;
        }

        set
        {
            eventUnitCanStopInAirChanged = value;
        }
    }

    public UnityEvent EventUnitHasCellResidenceChanged
    {
        get
        {
            if (eventUnitHasCellResidenceChanged == null)
            {
                eventUnitHasCellResidenceChanged = new UnityEvent();
            }
            return eventUnitHasCellResidenceChanged;
        }

        set
        {
            eventUnitHasCellResidenceChanged = value;
        }
    }

    public UnityEvent EventUnitCellResidenceChanged
    {
        get
        {
            if (eventUnitCellResidenceChanged == null)
            {
                eventUnitCellResidenceChanged = new UnityEvent();
            }
            return eventUnitCellResidenceChanged;
        }

        set
        {
            eventUnitCellResidenceChanged = value;
        }
    }

    public UnityEvent EventUnitOnTurnChanged
    {
        get
        {
            if (eventUnitOnTurnChanged == null)
            {
                eventUnitOnTurnChanged = new UnityEvent();
            }
            return eventUnitOnTurnChanged;
        }

        set
        {
            eventUnitOnTurnChanged = value;
        }
    }

    public UnityEvent EventUnitTurnWaitValueChanged
    {
        get
        {
            if (eventUnitTurnWaitValueChanged == null)
            {
                eventUnitTurnWaitValueChanged = new UnityEvent();
            }
            return eventUnitTurnWaitValueChanged;
        }

        set
        {
            eventUnitTurnWaitValueChanged = value;
        }
    }

    public UnityEvent EventUnitEnergyUsedChanged
    {
        get
        {
            if (eventUnitEnergyUsedChanged == null)
            {
                eventUnitEnergyUsedChanged = new UnityEvent();
            }
            return eventUnitEnergyUsedChanged;
        }

        set
        {
            eventUnitEnergyUsedChanged = value;
        }
    }



    #endregion
    #region Constructors
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public void AddAbility(AbilityModel ability)
    {
        if (ability == null)
        {
            return;
        }
        if (UnitAbilities == null)
        {
            UnitAbilities = new List<AbilityModel>();
        }
        UnitAbilities.Add(ability);
        EventUnitAbilityAdded.Invoke(ability);
    }

    public void RemoveAbility(AbilityModel ability)
    {
        if (ability == null)
        {
            return;
        }
        if(UnitAbilities == null)
        {
            return;
        }
        if (!UnitAbilities.Contains(ability))
        {
            return;
        }
        UnitAbilities.Remove(ability);
        EventUnitAbilityRemoved.Invoke(ability);
    }

    public void AddStatus(StatusModel status)
    {
        if (status == null)
        {
            return;
        }
        if (UnitStatuses == null)
        {
            UnitStatuses = new List<StatusModel>();
        }
        UnitStatuses.Add(status);
        EventUnitStatusAdded.Invoke(status);
    }

    public void RemoveStatus(StatusModel status)
    {
        if (status == null)
        {
            return;
        }
        if (UnitStatuses == null)
        {
            return;
        }
        if (!UnitStatuses.Contains(status))
        {
            return;
        }
        UnitStatuses.Remove(status);
        EventUnitStatusRemoved.Invoke(status);
    }

    public void InitialisePathList(CellManagerSO cellManager)
    {
        PathList = new PathModel[cellManager.GridWidth * cellManager.GridHeight];
        // Create the paths
        for (int count = 0; count < cellManager.GridWidth * cellManager.GridHeight; count++)
        {
            PathList[count] = new PathModel(cellManager.CellModelList[count]);
        }
        // Set adjacent paths
        for (int count = 0; count < cellManager.GridWidth * cellManager.GridHeight; count++)
        {
            foreach (CellModel cell in cellManager.CellModelList[count].CellAdjacentCells)
            {
                PathList[count].AddAdjacentPath(GetPath(cell.CellGridPositionX, cell.CellGridPositionY, cellManager.GridWidth));
            }
        }
    }

    public void CalculatePathing(int gridWidth)
    {
        ClearPathing();
        PathModel pathCurrentlyChecking = GetPath(unitCellResidence.CellGridPositionX, unitCellResidence.CellGridPositionY, gridWidth);
        pathCurrentlyChecking.StartPath();
        Queue<PathModel> pathsToCheckQueue = new Queue<PathModel>();
        pathsToCheckQueue.Enqueue(pathCurrentlyChecking);
        while(pathsToCheckQueue.Count > 0)
        {
            pathCurrentlyChecking = pathsToCheckQueue.Dequeue();
            foreach (PathModel adjacentPath in pathCurrentlyChecking.AdjacentPaths)
            {
                if (!adjacentPath.HasPath || (adjacentPath.HasPath && adjacentPath.PathLength > pathCurrentlyChecking.PathLength + 1))
                {
                    adjacentPath.PathQueue = pathCurrentlyChecking.PathQueue;
                    if (adjacentPath.Cell.CellIsLandDestination) // Can set future conditions for flying etc.
                    {
                        pathCurrentlyChecking.CanStop = true;
                    }
                    if (adjacentPath.Cell.CellIsLandTraversable) // If can't pass through don't add to the checking queue. Also add more in future.
                    {
                        pathCurrentlyChecking.CanPassThrough = true;
                        if (!pathsToCheckQueue.Contains(adjacentPath)) // If adjacent path isn't already in Paths To Check Queue add adjacent path to the queue
                        {
                            pathsToCheckQueue.Enqueue(adjacentPath);
                        }
                    }
                }
            }
        }
    }

    public void ClearPathing()
    {
        foreach(PathModel path in PathList)
        {
            path.ClearPath();
        }
    }

    public PathModel GetPath(int x, int y, int gridWidth)
    {
        int listNumber = x * gridWidth + y;
        return PathList[listNumber];
    }

    public void SetPath(PathModel path, int x, int y, int gridWidth)
    {
        int listNumber = x * gridWidth + y;
        PathList[listNumber] = path;
    }

    public void RemovePath(int x, int y, int gridWidth)
    {
        int listNumber = x * gridWidth + y;
        PathList[listNumber] = null;
    }

    public void DequeueNextPathFromQueue()
    {
        HasCurrentDestination = true;
        MoveCurrentPath = MovePathQueue.Dequeue();
    }

    #endregion
}

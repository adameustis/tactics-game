using System.Collections.Generic;
using MVC.Cell;
using ScriptableObjects.UnitSO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEvents;

namespace MVC.Unit
{
    [System.Serializable]
    public class UnitModel
    {
        #region Fields

        [field: Header("Fields")]
        [SerializeField] private UnitSO staticData;
        [SerializeField] private Vector3 transformPosition;
        [SerializeField] private int gridPositionX;
        [SerializeField] private int gridPositionY;
        [SerializeField] private int unitNumber;
        [SerializeField] private string unitName;
        [SerializeField] private Sprite unitIcon;
        [FormerlySerializedAs("unitHP")] [SerializeField] private int unitHealth;
        [FormerlySerializedAs("unitMaxHP")] [SerializeField] private int unitMaxHealth;

        [SerializeField] private List<AbilityModel> unitAbilities;
        [SerializeField] private List<StatusModel> unitStatuses;

        [SerializeField] private bool unitCanLandTraverse;
        [SerializeField] private bool unitCanAirTraverse;
        [SerializeField] private bool unitCanStopOnLand;
        [SerializeField] private bool unitCanStopInAir;

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

        [SerializeField] private UnityEvent<Vector3> eventTransformPositionChanged;
        [SerializeField] private UnityEvent eventUnitNumberChanged;
        [SerializeField] private UnityEvent eventUnitNameChanged;
        [SerializeField] private UnityEvent eventUnitIconChanged;
        [FormerlySerializedAs("eventUnitHPChanged")] [SerializeField] private UnityEvent eventUnitHealthChanged;
        [FormerlySerializedAs("eventUnitMaxHPChanged")] [SerializeField] private UnityEvent eventUnitMaxHealthChanged;
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

        public UnitSO StaticData { get => staticData; set => staticData = value; }

        public virtual Vector3 TransformPosition
        {
            get => transformPosition;

            set
            {
                if (transformPosition == value) return;
                transformPosition = value;
                EventTransformPositionChanged.Invoke(transformPosition);
            }
        }

        public int GridPositionX { get => gridPositionX; set => gridPositionX = value; }
        public int GridPositionY { get => gridPositionY; set => gridPositionY = value; }

        public int UnitNumber
        {
            get => unitNumber;

            set
            {
                if (unitNumber == value) return;
                unitNumber = value;
                EventUnitNumberChanged.Invoke();
            }
        }

        public string UnitName
        {
            get => unitName;

            set
            {
                if (unitName == value) return;
                unitName = value;
                EventUnitNameChanged.Invoke();
            }
        }

        public Sprite UnitIcon
        {
            get => unitIcon;

            set
            {
                if (unitIcon == value) return;
                unitIcon = value;
                EventUnitIconChanged.Invoke();
            }
        }

        public int UnitHealth
        {
            get => unitHealth;

            private set
            {
                if (unitHealth == value) return;
                unitHealth = value < 0 ? 0 : value;
                EventUnitHealthChanged.Invoke();
            }
        }

        public int UnitMaxHealth
        {
            get => unitMaxHealth;

            set
            {
                if (unitMaxHealth == value) return;
                unitMaxHealth = value < 0 ? 0 : value;
                EventUnitMaxHealthChanged.Invoke();
            }
        }

        public List<AbilityModel> UnitAbilities
        {
            get => unitAbilities;
            // Private because if events are put here they won't fire for .Add() method etc.
            private set => unitAbilities = value;
        }

        public List<StatusModel> UnitStatuses
        {
            get => unitStatuses;
            // Private because if events are put here they won't fire for .Add() method etc.
            private set => unitStatuses = value;
        }

        public bool UnitCanLandTraverse
        {
            get => unitCanLandTraverse;

            set
            {
                if (unitCanLandTraverse == value) return;
                unitCanLandTraverse = value;
                EventUnitCanLandTraverseChanged.Invoke();
            }
        }

        public bool UnitCanAirTraverse
        {
            get => unitCanAirTraverse;

            set
            {
                if (unitCanAirTraverse == value) return;
                unitCanAirTraverse = value;
                EventUnitCanAirTraverseChanged.Invoke();
            }
        }

        public bool UnitCanStopOnLand
        {
            get => unitCanStopOnLand;

            set
            {
                if (unitCanStopOnLand == value) return;
                unitCanStopOnLand = value;
                EventUnitCanStopOnLandChanged.Invoke();
            }
        }

        public bool UnitCanStopInAir
        {
            get => unitCanStopInAir;

            set
            {
                if (unitCanStopInAir == value) return;
                unitCanStopInAir = value;
                EventUnitCanStopInAirChanged.Invoke();
            }
        }

        public bool UnitOnTurn
        {
            get => unitOnTurn;

            private set
            {
                if (unitOnTurn == value) return;
                unitOnTurn = value;
                EventUnitOnTurnChanged.Invoke();
            }
        }

        public int UnitTurnWaitValue
        {
            get => unitTurnWaitValue;

            set
            {
                if (unitTurnWaitValue == value) return;
                
                unitTurnWaitValue = unitTurnWaitValue < 0 ? 0 : value;
                EventUnitTurnWaitValueChanged.Invoke();
            }
        }

        public int UnitEnergyUsed
        {
            get => unitEnergyUsed;

            set
            {
                if (unitEnergyUsed == value) return;
                unitEnergyUsed = value;
                EventUnitEnergyUsedChanged.Invoke();
            }
        }

        public bool HasCurrentDestination { get => hasCurrentDestination; set => hasCurrentDestination = value; }
        public float Speed { get => speed; set => speed = value; }
        public Queue<PathModel> MovePathQueue
        {
            get => movePathQueue;

            set { movePathQueue = value != null ? new Queue<PathModel>(value) : null; }
        }
        public PathModel MoveCurrentPath { get => moveCurrentPath; set => moveCurrentPath = value; }

        public PathModel[] PathList { get => pathList; set => pathList = value; }

        #endregion
        #region Events Properties

        public UnityEvent<Vector3> EventTransformPositionChanged { get => eventTransformPositionChanged; set => eventTransformPositionChanged = value; }
        public UnityEvent EventUnitNumberChanged { get => eventUnitNumberChanged; set => eventUnitNumberChanged = value; }
        public UnityEvent EventUnitNameChanged { get => eventUnitNameChanged; set => eventUnitNameChanged = value; }
        public UnityEvent EventUnitIconChanged { get => eventUnitIconChanged; set => eventUnitIconChanged = value; }
        public UnityEvent EventUnitHealthChanged { get => eventUnitHealthChanged; set => eventUnitHealthChanged = value; }
        public UnityEvent EventUnitMaxHealthChanged { get => eventUnitMaxHealthChanged; set => eventUnitMaxHealthChanged = value; }
        public UnityEventAbilityModel EventUnitAbilityAdded { get => eventUnitAbilityAdded; set => eventUnitAbilityAdded = value; }
        public UnityEventAbilityModel EventUnitAbilityRemoved { get => eventUnitAbilityRemoved; set => eventUnitAbilityRemoved = value; }
        public UnityEventStatusModel EventUnitStatusAdded { get => eventUnitStatusAdded; set => eventUnitStatusAdded = value; }
        public UnityEventStatusModel EventUnitStatusRemoved { get => eventUnitStatusRemoved; set => eventUnitStatusRemoved = value; }
        public UnityEvent EventUnitCanLandTraverseChanged { get => eventUnitCanLandTraverseChanged; set => eventUnitCanLandTraverseChanged = value; }
        public UnityEvent EventUnitCanAirTraverseChanged { get => eventUnitCanAirTraverseChanged; set => eventUnitCanAirTraverseChanged = value; }
        public UnityEvent EventUnitCanStopOnLandChanged { get => eventUnitCanStopOnLandChanged; set => eventUnitCanStopOnLandChanged = value; }
        public UnityEvent EventUnitCanStopInAirChanged { get => eventUnitCanStopInAirChanged; set => eventUnitCanStopInAirChanged = value; }
        public UnityEvent EventUnitHasCellResidenceChanged { get => eventUnitHasCellResidenceChanged; set => eventUnitHasCellResidenceChanged = value; }
        public UnityEvent EventUnitCellResidenceChanged { get => eventUnitCellResidenceChanged; set => eventUnitCellResidenceChanged = value; }
        public UnityEvent EventUnitOnTurnChanged { get => eventUnitOnTurnChanged; set => eventUnitOnTurnChanged = value; }
        public UnityEvent EventUnitTurnWaitValueChanged { get => eventUnitTurnWaitValueChanged; set => eventUnitTurnWaitValueChanged = value; }
        public UnityEvent EventUnitEnergyUsedChanged { get => eventUnitEnergyUsedChanged; set => eventUnitEnergyUsedChanged = value; }

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

        public void InitialiseTurn()
        {
            UnitOnTurn = true;
            foreach (var ability in UnitAbilities)
                ability.EffectiveUses = ability.Ability.Uses;
        }
        
        public void EndTurn()
        {
            UnitTurnWaitValue += 5;
            UnitOnTurn = false;
            foreach (var ability in UnitAbilities)
                ability.EffectiveUses = 0;
        }

        public void DamageUnit(int amount)
        {
            UnitHealth -= amount;
        }
        
        // public void InitialisePathList(CellManagerSO cellManager)
        // {
        //     PathList = new PathModel[cellManager.GridWidth * cellManager.GridHeight];
        //     // Create the paths
        //     for (int count = 0; count < cellManager.GridWidth * cellManager.GridHeight; count++)
        //     {
        //         PathList[count] = new PathModel(cellManager.CellModelList[count]);
        //     }
        //     // Set adjacent paths
        //     for (int count = 0; count < cellManager.GridWidth * cellManager.GridHeight; count++)
        //     {
        //         foreach (CellModel cell in cellManager.CellModelList[count].CellAdjacentCells)
        //         {
        //             PathList[count].AddAdjacentPath(GetPath(cell.CellGridPositionX, cell.CellGridPositionY, cellManager.GridWidth));
        //         }
        //     }
        // }

        // public void CalculatePathing(int gridWidth)
        // {
        //     ClearPathing();
        //     PathModel pathCurrentlyChecking = GetPath(unitCellResidence.CellGridPositionX, unitCellResidence.CellGridPositionY, gridWidth);
        //     pathCurrentlyChecking.StartPath();
        //     Queue<PathModel> pathsToCheckQueue = new Queue<PathModel>();
        //     pathsToCheckQueue.Enqueue(pathCurrentlyChecking);
        //     while(pathsToCheckQueue.Count > 0)
        //     {
        //         pathCurrentlyChecking = pathsToCheckQueue.Dequeue();
        //         foreach (PathModel adjacentPath in pathCurrentlyChecking.AdjacentPaths)
        //         {
        //             if (!adjacentPath.HasPath || (adjacentPath.HasPath && adjacentPath.PathLength > pathCurrentlyChecking.PathLength + 1))
        //             {
        //                 adjacentPath.PathQueue = pathCurrentlyChecking.PathQueue;
        //                 if (adjacentPath.Cell.StaticData.CellIsLandDestination) // Can set future conditions for flying etc.
        //                 {
        //                     pathCurrentlyChecking.CanStop = true;
        //                 }
        //                 if (adjacentPath.Cell.StaticData.CellIsLandTraversable) // If can't pass through don't add to the checking queue. Also add more in future.
        //                 {
        //                     pathCurrentlyChecking.CanPassThrough = true;
        //                     if (!pathsToCheckQueue.Contains(adjacentPath)) // If adjacent path isn't already in Paths To Check Queue add adjacent path to the queue
        //                     {
        //                         pathsToCheckQueue.Enqueue(adjacentPath);
        //                     }
        //                 }
        //             }
        //         }
        //     }
        // }

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
}

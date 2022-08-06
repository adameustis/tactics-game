using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveController : MonoBehaviour
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private UnitModel model;
    [SerializeField] private GameManagerSO gameManager;
    [SerializeField] private bool isMoving;

    #endregion
    #region Events

    [Header("Events")]
    [SerializeField] private UnityEvent eventIsMoving;

    #endregion
    #region Properties

    public UnitModel Model { get => model; set => model = value; }
    public GameManagerSO GameManager { get => gameManager; set => gameManager = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }

    #endregion
    #region Event Properties

    public UnityEvent EventIsMoving
    {
        get
        {
            if (eventIsMoving == null)
            {
                eventIsMoving = new UnityEvent();
            }
            return eventIsMoving;
        }

        set
        {
            eventIsMoving = value;
        }
    }

    

    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        // View.EventIsMoving.AddListener(HandleViewIsMoving);
    }

    public void UnsubscribeFromEvents()
    {
        // View.EventIsMoving.RemoveListener(HandleViewIsMoving);
    }

    #endregion
    #region Event Handlers

    public void HandleViewIsMoving()
    {
        MoveUnit();
    }

    #endregion
    #region Monobehaviour

    private void Update()
    {
        if (isMoving)
        {
            EventIsMoving.Invoke();
        }
    }

    public void Start()
    {
        //Initialise();
    }

    public void OnDestroy()
    {
        GameManager.UnitManager.RemoveUnitModel(Model);
        UnsubscribeFromEvents();
    }
    
    #endregion
    #region Methods
    
   public InstructionSO SelectMoveTarget(CellBattleController cellController)
    {
        InstructionSO instruction = GameManager.InstructionManager.Select;
        PathModel path = Model.GetPath(cellController.Model.CellGridPositionX, cellController.Model.CellGridPositionY, GameManager.CellManager.GridWidth);
        if (path == null)
        {
            //Do nothing
        }
        else if (!path.HasPath)
        {
            //Do nothing as no path available
        }
        else if (!path.CanStop)
        {
            //Do nothing as can't move here
        }
        else
        {
            instruction = GameManager.InstructionManager.DoNothing;

            // Stop displaying Move Arrow
            PathModel[] movePathArray = Model.MovePathQueue.ToArray();
            //StopDisplayingMoveArrow(movePathArray[Model.MovePathQueue.Count - 1].Cell);

            // Stop displaying Move Lines
            //StopDisplayingMoveLine(Model.MovePathQueue);

            // Start moving
            StartMovingUnit(Model.MovePathQueue);
        }
        return instruction;
    }

    public void StartMovingUnit(Queue<PathModel> pathQueue)
    {
        if (pathQueue == null)
        {
            //Do nothing as no path
        }
        else
        {
            Model.MovePathQueue = pathQueue;
            //Model.State = GameManager.StateManager.StateSOUnitMoving;
            IsMoving = true;
        }
    }

    public void MoveUnit()
    {
        if (!Model.HasCurrentDestination)
        {
            Model.DequeueNextPathFromQueue();
        }

        Vector3 destination = Model.MoveCurrentPath.Cell.TransformPosition;
        destination.z = Model.TransformPosition.z;
        Move(Model.MoveCurrentPath.Cell.TransformPosition, Model.Speed);

        if (Vector3.Distance(Model.TransformPosition, destination) <= 0.05f)
        {
            Model.TransformPosition = destination;
            Model.HasCurrentDestination = false;
            Model.UnitCellResidence = Model.MoveCurrentPath.Cell;
            if (Model.MovePathQueue.Count == 0)
            {
                FinishMovingUnit();
            }
        }
    }

    public void Move(Vector3 destination, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    public void FinishMovingUnit()
    {
        IsMoving = false;
        //Model.State = GameManager.StateManager.StateSOSelected;
    }

    public InstructionSO MouseOverMoveTarget(CellBattleController cellController)
    {
        InstructionSO instruction = GameManager.InstructionManager.MouseOver;
        CellModel mouseOverCell = cellController.Model;
        PathModel mouseOverPath = Model.GetPath(mouseOverCell.CellGridPositionX, mouseOverCell.CellGridPositionY, GameManager.CellManager.GridWidth);
        
        if (mouseOverPath == null)
        {
            //Do nothing
        }
        else if (!mouseOverPath.HasPath)
        {
            //Do nothing as no path available
        }
        else if (!mouseOverPath.CanPassThrough)
        {
            //Do nothing as can't pass through here
        }
        else
        {
            instruction = GameManager.InstructionManager.DoNothing;
            PathModel[] movePathArray;
            CellModel previousMouseOvercell;

            // Check if not displaying
            if (Model.MovePathQueue == null || Model.MovePathQueue.Count == 0)
            {
                Model.MovePathQueue = Model.GetPath(mouseOverCell.CellGridPositionX, mouseOverCell.CellGridPositionY, GameManager.CellManager.GridWidth).PathQueue;
                movePathArray = Model.MovePathQueue.ToArray();
                previousMouseOvercell = movePathArray[Model.MovePathQueue.Count - 2].Cell;
                // Check if mouse over cell is further away then adjacent to cell under unit in which case a line will need to be shown
                if (Model.MovePathQueue.Count > 2)
                {
                    // Display generated path since the mouse over is out of order
                    //DisplayMoveLine(Model.MovePathQueue);
                }
            }
            else // if already displaying
            {
                movePathArray = Model.MovePathQueue.ToArray();
                previousMouseOvercell = movePathArray[Model.MovePathQueue.Count - 1].Cell;

                // Stop displaying Move Arrow
                // StopDisplayingMoveArrow(previousMouseOvercell);
                //
                // // Check is adjacent
                // if (CheckIfTwoCellsAreAdjacent(previousMouseOvercell.CellGridPositionX, previousMouseOvercell.CellGridPositionY, mouseOverCell.CellGridPositionX, mouseOverCell.CellGridPositionY))
                // {
                //
                //     if (Model.MovePathQueue.Count > 1) // If there is previous, previous mouse over cell then show line in previous
                //     {
                //         DisplayMoveLine(previousMouseOvercell, movePathArray[movePathArray.Length - 2].Cell, mouseOverCell);
                //     }
                //
                //     Model.MovePathQueue.Enqueue(mouseOverPath);
                // }
                // else // If cells are not adjacent
                // {
                //     // Stop displaying Move Lines
                //     StopDisplayingMoveLine(Model.MovePathQueue);
                //
                //     // Display generated path since the mouse over is out of order
                //     Model.MovePathQueue = new Queue<PathModel>(Model.GetPath(mouseOverCell.CellGridPositionX, mouseOverCell.CellGridPositionY, GameManager.CellManager.GridWidth).PathQueue);
                //     DisplayMoveLine(Model.MovePathQueue);
                //     movePathArray = Model.MovePathQueue.ToArray();
                //     previousMouseOvercell = movePathArray[Model.MovePathQueue.Count - 2].Cell;
                // }
            }

            // Display arrow over current mouse over
            //cellController.DisplayMoveArrow(previousMouseOvercell);
        }
        return instruction;
    }
    
    #endregion
}

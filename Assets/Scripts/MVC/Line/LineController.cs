using System.Collections;
using System.Collections.Generic;
using MVC.Cell;
using UnityEngine;

public class LineController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Animator moveLineAnimator;
    [SerializeField] private CellModel model;

    #endregion
    #region Events
    #endregion
    #region Properties

    public Animator MoveLineAnimator { get => moveLineAnimator; set => moveLineAnimator = value; }
    public bool IsDisplayingArrow { get => MoveLineAnimator.GetBool("isDisplaying"); }
    public CellModel Model
    {
        get => model;
        private set => model = value;
    }
    
    #endregion
    #region Event Properties

    #endregion
    #region MonoBehaviour
    public virtual void Start()
    {
        Initialise(transform.GetComponent<CellController>().Model);
    }

    #endregion
    #region Methods

    public void Initialise(CellModel setModel)
    {
        Model = setModel;
    }

    public void DisplayMoveLine(Queue<PathModel> setPathQueue)
    {
        Queue<PathModel> movePathQueue = new Queue<PathModel>(setPathQueue);
        PathModel currentPath = movePathQueue.Dequeue();
        PathModel previousPath;
        PathModel nextPath;
        while (movePathQueue.Count > 1)
        {
            previousPath = currentPath;
            currentPath = movePathQueue.Dequeue();
            nextPath = movePathQueue.Peek();
            DisplayMoveLine(currentPath.Cell, previousPath.Cell, nextPath.Cell);
        }
    }
    
    public void StopDisplayingMoveLine(Queue<PathModel> setPathQueue)
    {
        // Queue<PathModel> movePathQueue = new Queue<PathModel>(setPathQueue);
        // movePathQueue.Dequeue();
        // while(movePathQueue.Count > 1)
        // {
        //     CellModel cell = movePathQueue.Dequeue().Cell;
        //     GameManager.CellManager.GetCellBattleController(cell.CellGridPositionX, cell.CellGridPositionY).StopDisplayingMoveLine();
        // }
        // IsDisplayingMoveLine = false;
    }
    
    public void DisplayMoveLine(CellModel displayCell, CellModel previousCell, CellModel nextCell)
    {
        // List<CellModel> entryAndExitCellsForLine = new List<CellModel>();
        // entryAndExitCellsForLine.Add(previousCell); // This is the adjacent entrance cell (The cell which preceded the previous cell)
        // entryAndExitCellsForLine.Add(nextCell); // This is the adjacent exit cell
        // GameManager.CellManager.GetCellBattleController(displayCell.CellGridPositionX, displayCell.CellGridPositionY).DisplayMoveLine(entryAndExitCellsForLine);
        // IsDisplayingMoveLine = true;
    }
    
    public void DisplayMoveLine(List<CellModel> entryAndExitAdjacentCellsList)
    {
        
        bool above = MoveLineAnimator.GetBool("above");
        bool below = MoveLineAnimator.GetBool("below");
        bool left = MoveLineAnimator.GetBool("left");
        bool right = MoveLineAnimator.GetBool("right");

        foreach (CellModel cell in entryAndExitAdjacentCellsList)
        {
            if (cell.CellGridPositionX == Model.CellGridPositionX && cell.CellGridPositionY == Model.CellGridPositionY + 1) //Check above
            {
                above = true;
            }
            else if (cell.CellGridPositionX == Model.CellGridPositionX && cell.CellGridPositionY == Model.CellGridPositionY - 1) //Check down
            {
                below = true;
            }
            else if (cell.CellGridPositionX == Model.CellGridPositionX - 1 && cell.CellGridPositionY == Model.CellGridPositionY) //Check left
            {
                left = true;
            }
            else if (cell.CellGridPositionX == Model.CellGridPositionX + 1 && cell.CellGridPositionY == Model.CellGridPositionY) //Check right
            {
                right = true;
            }
            else // Not adjacent
            {
                // Do nothing
            }
        }

        if(above || below || left || right)
        {
            DisplayMoveLine(above, below, left, right);
        }
    }
    
    public void DisplayMoveLine(bool above, bool below, bool left, bool right)
    {
        MoveLineAnimator.SetBool("isDisplaying", false); //This is here to reset the animation before setting a new one
        MoveLineAnimator.SetBool("above", above);
        MoveLineAnimator.SetBool("below", below);
        MoveLineAnimator.SetBool("left", left);
        MoveLineAnimator.SetBool("right", right);
        MoveLineAnimator.SetBool("isDisplaying", true);
    }


    
    public void StopDisplayingMoveLine()
    {
        MoveLineAnimator.SetBool("isDisplaying", false);
        MoveLineAnimator.SetBool("above", false);
        MoveLineAnimator.SetBool("below", false);
        MoveLineAnimator.SetBool("left", false);
        MoveLineAnimator.SetBool("right", false);
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArrowController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Animator moveArrowAnimator;
    [SerializeField] private CellModel model;

    #endregion
    #region Events
    #endregion
    #region Properties

    public Animator MoveArrowAnimator { get => moveArrowAnimator; set => moveArrowAnimator = value; }
    public bool IsDisplayingArrow => MoveArrowAnimator.GetBool("isDisplaying");

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
        Initialise(transform.GetComponent<CellBattleController>().Model);
    }

    #endregion
    #region Methods

    public void Initialise(CellModel setModel)
    {
        Model = setModel;
    }
    
    public void StopDisplayingMoveArrow(CellModel cell)
    {
        // if(Model.MovePathQueue.Count > 1)
        // {
        //     GameManager.CellManager.GetCellBattleController(cell.CellGridPositionX, cell.CellGridPositionY).StopDisplayingMoveArrow();
        //     IsDisplayingMoveArrow = false;
        // }
    }
    
    public void DisplayMoveArrow(CellModel entranceCell)
    {
        if (entranceCell.CellGridPositionX == Model.CellGridPositionX && entranceCell.CellGridPositionY == Model.CellGridPositionY + 1) //Check above
        {
            DisplayMoveArrow(true, false, false, false);
        }
        else if (entranceCell.CellGridPositionX == Model.CellGridPositionX && entranceCell.CellGridPositionY == Model.CellGridPositionY - 1) //Check down
        {
            DisplayMoveArrow(false, true, false, false);
        }
        else if (entranceCell.CellGridPositionX == Model.CellGridPositionX - 1 && entranceCell.CellGridPositionY == Model.CellGridPositionY) //Check left
        {
            DisplayMoveArrow(false, false, true, false);
        }
        else if (entranceCell.CellGridPositionX == Model.CellGridPositionX + 1 && entranceCell.CellGridPositionY == Model.CellGridPositionY) //Check right
        {
            DisplayMoveArrow(false, false, false, true);
        }
        else // Not adjacent
        {
            // Do nothing
        }
    }
    
    public void DisplayMoveArrow(bool above, bool below, bool left, bool right)
    {
        MoveArrowAnimator.SetBool("isDisplaying", false); //This is here to reset the animation before setting a new one
        MoveArrowAnimator.SetBool("above", above);
        MoveArrowAnimator.SetBool("below", below);
        MoveArrowAnimator.SetBool("left", left);
        MoveArrowAnimator.SetBool("right", right);
        MoveArrowAnimator.SetBool("isDisplaying", true);
    }

    public void StopDisplayingMoveArrow()
    {
        MoveArrowAnimator.SetBool("isDisplaying", false);
        MoveArrowAnimator.SetBool("above", false);
        MoveArrowAnimator.SetBool("below", false);
        MoveArrowAnimator.SetBool("left", false);
        MoveArrowAnimator.SetBool("right", false);
    }

    #endregion
}

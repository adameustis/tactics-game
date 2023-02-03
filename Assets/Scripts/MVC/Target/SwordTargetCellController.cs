using System;
using MVC.Cell;
using MVC.Target;
using UnityEngine;

namespace MVC.TargetCell
{
    public class SwordTargetCellController : TargetController
    {
        #region Methods
        public override void Display()
        {
            CellController targetCell = target.GetComponent<CellController>();
            
            int sourceX = SourceUnit.Model.UnitCellResidence.CellGridPositionX;
            int destinationX = targetCell.Model.CellGridPositionX;

            bool valid = Math.Abs(sourceX - destinationX) == 1;
            
            TargetAnimator.SetBool(Valid, valid);
        }
        
        #endregion
    }
}
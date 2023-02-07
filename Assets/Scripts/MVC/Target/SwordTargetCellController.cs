using System;
using MVC.Cell;

namespace MVC.Target
{
    public class SwordTargetCellController : TargetController
    {
        #region Methods
        public override void Display()
        {
            CellController targetCell = target.GetComponent<CellController>();
            
            int sourceX = SourceUnit.Model.GridPositionX;
            int destinationX = targetCell.Model.CellGridPositionX;

            bool valid = Math.Abs(sourceX - destinationX) == 1;
            
            TargetAnimator.SetBool(Valid, valid);
        }
        
        #endregion
    }
}
using System;
using MVC.Target;

namespace MVC.TargetUnit
{
    public class SwordTargetUnitController : TargetUnitController
    {
        #region Methods

        public override void Display()
        {
            int sourceX = SourceUnit.Model.UnitCellResidence.CellGridPositionX;
            int destinationX = DestinationUnit.Model.UnitCellResidence.CellGridPositionX;

            bool valid = Math.Abs(sourceX - destinationX) == 1;
            
            TargetAnimator.SetBool(Valid, valid);
        }

        #endregion
    }
}
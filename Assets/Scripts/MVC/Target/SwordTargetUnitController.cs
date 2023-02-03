using System;
using MVC.Target;
using MVC.Unit;

namespace MVC.TargetUnit
{
    public class SwordTargetUnitController : TargetController
    {
        #region Methods

        public override void Display()
        {
            UnitController targetUnit = Target.GetComponent<UnitController>();
            
            int sourceX = SourceUnit.Model.UnitCellResidence.CellGridPositionX;
            int destinationX = targetUnit.Model.UnitCellResidence.CellGridPositionX;

            bool valid = Math.Abs(sourceX - destinationX) == 1;
            
            TargetAnimator.SetBool(Valid, valid);
        }

        #endregion
    }
}
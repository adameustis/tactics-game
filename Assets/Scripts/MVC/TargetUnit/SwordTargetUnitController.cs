using System;
using MVC.Target;

namespace MVC.TargetUnit
{
    public class SwordTargetUnitController : TargetController
    {
        #region Methods

        public override void Display()
        {
            UnitBattleController targetUnit = Target.GetComponent<UnitBattleController>();
            
            int sourceX = SourceUnit.Model.UnitCellResidence.CellGridPositionX;
            int destinationX = targetUnit.Model.UnitCellResidence.CellGridPositionX;

            bool valid = Math.Abs(sourceX - destinationX) == 1;
            
            TargetAnimator.SetBool(Valid, valid);
        }

        #endregion
    }
}
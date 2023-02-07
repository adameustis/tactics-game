using System;
using MVC.Unit;

namespace MVC.Target
{
    public class SwordTargetUnitController : TargetController
    {
        #region Methods

        public override void Display()
        {
            UnitController targetUnit = Target.GetComponent<UnitController>();
            
            int sourceX = SourceUnit.Model.GridPositionX;
            int destinationX = targetUnit.Model.GridPositionX;

            bool valid = Math.Abs(sourceX - destinationX) == 1;
            
            TargetAnimator.SetBool(Valid, valid);
        }

        #endregion
    }
}
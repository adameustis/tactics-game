using System;
using UnityEngine;

namespace MVC.TargetCell
{
    public class SwordTargetCellController : TargetCellController
    {
        public override void Display()
        {
            int sourceX = SourceUnit.Model.UnitCellResidence.CellGridPositionX;
            int destinationX = DestinationCell.Model.CellGridPositionX;

            bool valid = Math.Abs(sourceX - destinationX) == 1;
            
            TargetAnimator.SetBool(Valid, valid);
        }
    }
}
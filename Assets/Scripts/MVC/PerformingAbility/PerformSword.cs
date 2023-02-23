using System;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MVC.PerformingAbility
{
    public class PerformSword : Perform
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region

        private void OnEnable()
        {
            DoAbility();
        }

        #endregion
        #region Methods

        public void DoAbility()
        {
            if (Controller.Data.TargetCell.CellHasResidentUnit)
            {
                Controller.Data.TargetCell.CellResidentUnit.DamageUnit(1);
            }
            OnComplete.Invoke();
        }
        
        #endregion
    }
}
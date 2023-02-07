using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MVC.PerformingAbility
{
    public class SwordController : PerformAbilityController
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
        #region Monobehaviour
        #endregion
        #region Methods

        public void DoAbility()
        {
            if (destinationCell.Model.CellHasResidentUnit)
            {
                DestinationCell.Model.CellResidentUnit.DamageUnit(1);
            }
        }
        
        #endregion
    }
}
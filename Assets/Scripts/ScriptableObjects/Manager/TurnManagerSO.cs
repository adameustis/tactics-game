using System.Collections.Generic;
using System.Linq;
using MVC.Unit;
using UnityEngine;

namespace ScriptableObjects.Manager
{
    [CreateAssetMenu(fileName = "TurnManagerSO", menuName = "ScriptableObjects/Manager/TurnManagerSO")]
    public class TurnManagerSO : ScriptableObject
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] private List<UnitModel> unitsInTurnOrder;
        [SerializeField] private UnitModel currentTurnUnit;

        #endregion
        #region Properties

        public List<UnitModel> UnitsInTurnOrder { get => unitsInTurnOrder; private set => unitsInTurnOrder = value; }
        public UnitModel CurrentTurnUnit { get => currentTurnUnit; private set => currentTurnUnit = value; }

        #endregion
        #region Constructors
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        public void OnDisable()
        {
            UnitsInTurnOrder = null;
            CurrentTurnUnit = null;
        }

        public void Initialise(List<UnitModel> setUnitList)
        {
            UnitsInTurnOrder = new List<UnitModel>(setUnitList);
            foreach (UnitModel unit in UnitsInTurnOrder)
            {
                unit.UnitTurnWaitValue = Random.Range(1, UnitsInTurnOrder.Count);
            }
            UnitsInTurnOrder = UnitsInTurnOrder.OrderBy(unit => unit.UnitTurnWaitValue).ToList<UnitModel>();
        }

        public void StartNextTurn()
        {
            CurrentTurnUnit = UnitsInTurnOrder[0];
            CurrentTurnUnit.InitialiseTurn();
        }

        public void EndTurn()
        {
            CurrentTurnUnit.EndTurn();
            int turnWaitValue = CurrentTurnUnit.UnitTurnWaitValue;
            foreach (UnitModel unit in UnitsInTurnOrder)
            {
                unit.UnitTurnWaitValue = unit.UnitTurnWaitValue - turnWaitValue;
            }
            CurrentTurnUnit.UnitTurnWaitValue = CurrentTurnUnit.UnitEnergyUsed;
            UnitsInTurnOrder = UnitsInTurnOrder.OrderBy(unit => unit.UnitTurnWaitValue).ToList<UnitModel>();
        }

        #endregion
    }
}

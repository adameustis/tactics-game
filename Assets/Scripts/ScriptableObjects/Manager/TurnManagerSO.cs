using System;
using System.Collections.Generic;
using System.Linq;
using MVC.EventData;
using MVC.Unit;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEvents;
using Random = UnityEngine.Random;

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
        #region Fields
        [Header("Events")]
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> onEndTurn;

        #endregion
        #region Properties

        public List<UnitModel> UnitsInTurnOrder { get => unitsInTurnOrder; private set => unitsInTurnOrder = value; }
        public UnitModel CurrentTurnUnit { get => currentTurnUnit; private set => currentTurnUnit = value; }

        #endregion

        #region Event Properties
        public EventAbstractSO<UnityEventPlayerModelAndTransform> OnEndTurn { get => onEndTurn; private set => onEndTurn = value; }

        #endregion
        #region Constructors
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        private void OnEnable()
        {
            OnEndTurn.UnityEvent.AddListener(EndTurn);
        }

        private void OnDisable()
        {
            UnitsInTurnOrder = null;
            CurrentTurnUnit = null;
            OnEndTurn.UnityEvent.RemoveListener(EndTurn);
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

        public void EndTurn(PlayerAndTransformData context)
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

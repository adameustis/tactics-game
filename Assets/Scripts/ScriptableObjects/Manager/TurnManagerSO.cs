using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MVC.Unit;

[CreateAssetMenu(fileName = "TurnManagerSO", menuName = "ScriptableObjects/Manager/TurnManagerSO")]
public class TurnManagerSO : ScriptableObject, ISerializationCallbackReceiver
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private List<UnitModel> unitsInTurnOrder;
    [SerializeField] private UnitModel currentTurnUnit;

    #endregion
    #region Properties

    public List<UnitModel> UnitsInTurnOrder
    {
        get
        {
            return unitsInTurnOrder;
        }

        set
        {
            unitsInTurnOrder = value;
        }
    }

    public UnitModel CurrentTurnUnit
    {
        get
        {
            return currentTurnUnit;
        }

        set
        {
            currentTurnUnit = value;
        }
    }

    #endregion
    #region Constructors
    #endregion
    #region Event Subscriptions
    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public void OnEnable()
    {
        UnitsInTurnOrder = null;
        CurrentTurnUnit = null;
    }

    public void OnAfterDeserialize()
    {
    }

    public void Initialise(List<UnitModel> setUnitList)
    {
        UnitsInTurnOrder = new List<UnitModel>(setUnitList);
        foreach (UnitModel unit in UnitsInTurnOrder)
        {
            unit.UnitTurnWaitValue = Random.Range(1, UnitsInTurnOrder.Count);
        }
        UnitsInTurnOrder = UnitsInTurnOrder.OrderBy(unit => unit.UnitTurnWaitValue).ToList<UnitModel>();
        StartNextTurn();
    }

    public void StartNextTurn()
    {
        CurrentTurnUnit = UnitsInTurnOrder[0];
        CurrentTurnUnit.UnitOnTurn = true;
    }

    public void EndTurn()
    {
        CurrentTurnUnit.UnitOnTurn = false;
        int turnWaitValue = CurrentTurnUnit.UnitTurnWaitValue;
        foreach (UnitModel unit in UnitsInTurnOrder)
        {
            unit.UnitTurnWaitValue = unit.UnitTurnWaitValue - turnWaitValue;
        }
        CurrentTurnUnit.UnitTurnWaitValue = CurrentTurnUnit.UnitEnergyUsed;
        UnitsInTurnOrder = UnitsInTurnOrder.OrderBy(unit => unit.UnitTurnWaitValue).ToList<UnitModel>();
        StartNextTurn();
    }

    public void OnBeforeSerialize()
    {
        //throw new System.NotImplementedException();
    }

    #endregion
}

using System.Collections.Generic;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEvents;

[CreateAssetMenu(fileName = "UnitManagerSO", menuName = "ScriptableObjects/Manager/UnitManagerSO")]
[System.Serializable] public class UnitManagerSO : ScriptableObject, ISerializationCallbackReceiver
{

    #region Fields
    #endregion
    #region Events
    #endregion
    #region Properties
    [field: Header("Fields")]
    [field: SerializeField] public List<UnitModel> UnitModelList { get; private set; }
    [field: SerializeField] public List<UnitController> UnitBattleControllerList { get; private set; }

    #endregion
    #region Event Properties
    [field: Header("Events")]
    [field: SerializeField] public UnityEventUnitModel EventUnitModelAdded { get; private set; }
    [field: SerializeField] public UnityEventUnitModel EventUnitModelRemoved { get; private set; }
    [field: SerializeField] public UnityEventUnitBattleController EventUnitBattleControllerAdded { get; private set; }
    [field: SerializeField] public UnityEventUnitBattleController EventUnitBattleControllerRemoved { get; private set; }

    #endregion
    #region Methods

    public void OnAfterDeserialize()
    {
        Initialise();
    }

    //public void OnEnable()
    //{
    //    CreateCells();
    //}

    //public void OnDestroy()
    //{
    //    Clear();
    //}

    public void Initialise()
    {
        // UnitList = unitListInitialValue;
        UnitModelList = new List<UnitModel>();
        UnitBattleControllerList = new List<UnitController>();
    }

    public void CreateUnits(UnitManagerSettingsSO settings, CellManagerSO cellManager)
    {
        Debug.Log("UnitManagerSO - Create Units");
        foreach (UnitSettingsModel unitSettings in settings.UnitSettingsList)
        {
            InstantiatePrefab(unitSettings, cellManager.GetCellModel(unitSettings.Point.X, unitSettings.Point.Y), cellManager);
        }
    }

    public void InstantiatePrefab(UnitSettingsModel unitSettings, CellModel cell, CellManagerSO cellManager)
    {
        UnitController unitController = (UnitController)Instantiate(unitSettings.Prefab, cell.TransformPosition, Quaternion.identity);
        UnitModel unitModel = unitController.Model;
        unitModel.UnitNumber = unitSettings.UnitNumber;
        if (!string.IsNullOrEmpty(unitSettings.UnitName))
        {
            unitModel.UnitName = unitSettings.UnitName;
        }
        unitModel.UnitCellResidence = cell;
        unitController.Initialise();
        //unitModel.InitialisePathList(cellManager);
        AddUnitModel(unitController.Model);
        AddUnitBattleController(unitController);
        unitController.OnDestroyEvent.AddListener(RemoveUnitBattleController);
    }

    public void AddUnitModel(UnitModel unit)
    {
        if (UnitModelList.Contains(unit)) return;

        UnitModelList.Add(unit);
        EventUnitModelAdded.Invoke(unit);
    }

    public void RemoveUnitModel(UnitModel unit)
    {
        if (!UnitModelList.Contains(unit)) return;

        UnitModelList.Remove(unit);
        EventUnitModelRemoved.Invoke(unit);
    }

    public void AddUnitBattleController(UnitController unit)
    {
        if (UnitBattleControllerList.Contains(unit)) return;

        UnitBattleControllerList.Add(unit);
        EventUnitBattleControllerAdded.Invoke(unit);
    }

    public void RemoveUnitBattleController(UnitController unit)
    {
        if (!UnitBattleControllerList.Contains(unit)) return;

        unit.OnDestroyEvent.RemoveListener(RemoveUnitBattleController);
        UnitBattleControllerList.Remove(unit);
        RemoveUnitModel(unit.Model);
        EventUnitBattleControllerRemoved.Invoke(unit);
    }

    public void OnBeforeSerialize()
    {
    }

    //public void Clear()
    //{
    //    Debug.Log("UnitManagerSO - Destroy");
    //    foreach (UnitController unit in Units)
    //    {
    //        Destroy(unit.View.gameObject);
    //    }
    //}

    #endregion

}

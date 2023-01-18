using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [field: SerializeField] public List<UnitBattleController> UnitBattleControllerList { get; private set; }

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
        UnitBattleControllerList = new List<UnitBattleController>();
    }

    public void CreateUnits(UnitManagerSettingsSO settings, CellManagerSO cellManager)
    {
        Debug.Log("UnitManagerSO - Create Units");
        foreach (UnitSettingsModel unitSettings in settings.UnitSettingsList)
        {
            InstantiatePrefab(unitSettings, cellManager.GetCellModel(unitSettings.Point.X, unitSettings.Point.Y));
        }
    }

    public void InstantiatePrefab(UnitSettingsModel unitSettings, CellModel cell)
    {
        UnitBattleController unitController = (UnitBattleController)Instantiate(unitSettings.Prefab, cell.TransformPosition, Quaternion.identity);
        UnitModel unitModel = unitController.Model;
        unitModel.UnitNumber = unitSettings.UnitNumber;
        if (!string.IsNullOrEmpty(unitSettings.UnitName))
        {
            unitModel.UnitName = unitSettings.UnitName;
        }
        unitModel.UnitCellResidence = cell;
        unitController.Initialise();
    }

    public void AddUnitModel(UnitModel unit)
    {
        if (UnitModelList.Contains(unit))
        {
            // Don't add as already added
        }
        else
        {
            UnitModelList.Add(unit);
            EventUnitModelAdded.Invoke(unit);
        }
    }

    public void RemoveUnitModel(UnitModel unit)
    {
        if (UnitModelList.Contains(unit))
        {
            UnitModelList.Remove(unit);
            EventUnitModelAdded.Invoke(unit);
        }
        else
        {
            // Don't nothing as the unit is not in the list
        }
    }

    public void AddUnitBattleController(UnitBattleController unit)
    {
        if (UnitBattleControllerList.Contains(unit))
        {
            // Don't add as already added
        }
        else
        {
            UnitBattleControllerList.Add(unit);
            EventUnitBattleControllerAdded.Invoke(unit);
        }
    }

    public void RemoveUnitBattleController(UnitBattleController unit)
    {
        if (UnitBattleControllerList.Contains(unit))
        {
            UnitBattleControllerList.Remove(unit);
            EventUnitBattleControllerAdded.Invoke(unit);
        }
        else
        {
            // Don't nothing as the unit is not in the list
        }
    }

    public void OnBeforeSerialize()
    {
    }

    //public void Clear()
    //{
    //    Debug.Log("UnitManagerSO - Destroy");
    //    foreach (UnitBattleController unit in Units)
    //    {
    //        Destroy(unit.View.gameObject);
    //    }
    //}

    #endregion

}

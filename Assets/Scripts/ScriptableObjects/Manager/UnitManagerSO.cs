using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitManagerSO", menuName = "ScriptableObjects/Manager/UnitManagerSO")]
[System.Serializable] public class UnitManagerSO : ScriptableObject, ISerializationCallbackReceiver
{

    #region Fields

    [Header("Fields")]
    [SerializeField] private List<UnitModel> unitModelList;
    [SerializeField] private List<UnitBattleController> unitBattleControllerList;

    #endregion
    #region Events

    [Header("Events")]
    [SerializeField] private UnityEventUnitModel eventUnitModelAdded;
    [SerializeField] private UnityEventUnitModel eventUnitModelRemoved;
    [SerializeField] private UnityEventUnitBattleController eventUnitBattleControllerAdded;
    [SerializeField] private UnityEventUnitBattleController eventUnitBattleControllerRemoved;

    #endregion
    #region Properties

    public List<UnitModel> UnitModelList
    {
        get
        {
            if (unitModelList == null)
            {
                unitModelList = new List<UnitModel>();
            }
            return unitModelList;
        }

        private set
        {
            unitModelList = value;
        }
    }

    public List<UnitBattleController> UnitBattleControllerList
    {
        get
        {
            if (unitBattleControllerList == null)
            {
                unitBattleControllerList = new List<UnitBattleController>();
            }
            return unitBattleControllerList;
        }

        private set
        {
            unitBattleControllerList = value;
        }
    }

    #endregion
    #region Event Properties

    public UnityEventUnitModel EventUnitModelAdded
    {
        get
        {
            if (eventUnitModelAdded == null)
            {
                eventUnitModelAdded = new UnityEventUnitModel();
            }
            return eventUnitModelAdded;
        }

        set
        {
            eventUnitModelAdded = value;
        }
    }

    public UnityEventUnitModel EventUnitModelRemoved
    {
        get
        {
            if (eventUnitModelRemoved == null)
            {
                eventUnitModelRemoved = new UnityEventUnitModel();
            }
            return eventUnitModelRemoved;
        }

        set
        {
            eventUnitModelRemoved = value;
        }
    }

    public UnityEventUnitBattleController EventUnitBattleControllerAdded
    {
        get
        {
            if (eventUnitBattleControllerAdded == null)
            {
                eventUnitBattleControllerAdded = new UnityEventUnitBattleController();
            }
            return eventUnitBattleControllerAdded;
        }

        set
        {
            eventUnitBattleControllerAdded = value;
        }
    }

    public UnityEventUnitBattleController EventUnitBattleControllerRemoved
    {
        get
        {
            if (eventUnitBattleControllerRemoved == null)
            {
                eventUnitBattleControllerRemoved = new UnityEventUnitBattleController();
            }
            return eventUnitBattleControllerRemoved;
        }

        set
        {
            eventUnitBattleControllerRemoved = value;
        }
    }



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

using System.Collections.Generic;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEvents;

namespace ScriptableObjects.Manager
{
    [CreateAssetMenu(fileName = "UnitManagerSO", menuName = "ScriptableObjects/Manager/UnitManagerSO")]
    [System.Serializable] public class UnitManagerSO : ScriptableObject
    {

        #region Fields
        [Header("Fields")]
        [SerializeField] private List<UnitModel> unitModelList;
    
        #endregion
        #region Events
        #endregion
        #region Properties
    
        public List<UnitModel> UnitModelList { get => unitModelList; private set => unitModelList = value; }

        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public UnityEventUnitModel EventUnitModelAdded { get; private set; }
        [field: SerializeField] public UnityEventUnitModel EventUnitModelRemoved { get; private set; }
        [field: SerializeField] public UnityEventUnitBattleController EventUnitBattleControllerAdded { get; private set; }
        [field: SerializeField] public UnityEventUnitBattleController EventUnitBattleControllerRemoved { get; private set; }

        #endregion
        #region Methods

        private void OnEnable()
        {
            UnitModelList = new List<UnitModel>();
        }

        private void OnDisable()
        {
            UnitModelList.Clear();
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

            unitModel.GridPositionX = cell.CellGridPositionX;
            unitModel.GridPositionY = cell.CellGridPositionY;
            unitModel.TransformPosition = cell.TransformPosition;
            cell.CellResidentUnit = unitModel;
            //unitModel.InitialisePathList(cellManager);
            AddUnitModel(unitController.Model);
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

        #endregion

    }
}

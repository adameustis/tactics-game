using System.Collections.Generic;
using System.Linq;
using MVC.Cell;
using MVC.EventData;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Serialization;

namespace MVC.SelectArea
{
    public class SelectAreaFactory : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private RectTransform selectAreaContainer;
        [SerializeField] private SelectAreaController selectAreaCellAndUnitPrefab;
        [SerializeField] private SelectAreaController selectAreaCellOnlyPrefab;
        [SerializeField] private List<SelectAreaController> spawnedSelectAreas;
        [SerializeField] private CellManagerSO cellManager;
        
        #endregion
        #region Events
        #endregion
        #region Properties
        
        public RectTransform SelectAreaContainer { get => selectAreaContainer; private set => selectAreaContainer = value; }
        public SelectAreaController SelectAreaCellAndUnitPrefab { get => selectAreaCellAndUnitPrefab; private set => selectAreaCellAndUnitPrefab = value; }
        public SelectAreaController SelectAreaCellOnlyPrefab { get => selectAreaCellOnlyPrefab; private set => selectAreaCellOnlyPrefab = value; }
        public List<SelectAreaController> SpawnedSelectAreas { get => spawnedSelectAreas; private set => spawnedSelectAreas = value; }
        public CellManagerSO CellManager { get => cellManager; set => cellManager = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
    
        public void HandleOnEnterState(PlayerAndTransformEventData context)
        {
            Display(context.Player, CellManager.CellModelList);
        }
        
        public void HandleOnExitState(PlayerAndTransformEventData context)
        {
            Clear();
        }
    
        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        private void Display(PlayerModel setPlayer, CellModel[] cellModels)
        {
            if (cellModels == null) return;
            if (!cellModels.Any()) return;
            
            foreach (var cell in cellModels)
            {
                var selectArea = Instantiate(cell.CellHasResidentUnit ? SelectAreaCellAndUnitPrefab : SelectAreaCellOnlyPrefab, SelectAreaContainer);
                selectArea.Initialise(setPlayer, cell);
                Debug.Log(selectArea);
                SpawnedSelectAreas.Add(selectArea);
            }

            SpawnedSelectAreas[0].UIButton.Select();
        }

        private void Clear()
        {
            if (SpawnedSelectAreas == null) return;
            if (!SpawnedSelectAreas.Any()) return;

            foreach (var menuItem in SpawnedSelectAreas)
                Destroy(menuItem.gameObject);

            SpawnedSelectAreas.Clear();
        }

        #endregion
    }
}
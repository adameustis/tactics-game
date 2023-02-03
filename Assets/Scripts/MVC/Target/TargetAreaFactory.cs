using System.Collections.Generic;
using MVC.Cell;
using MVC.EventModel;
using ScriptableObjects.Manager;
using UnityEngine;

namespace MVC.Target
{
    public class TargetAreaFactory : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public List<GameObject> SpawnedTargets { get; private set; }
        [field: SerializeField] public GameObject ValidTargetPrefab { get; private set; }
        [field: SerializeField] public GameObject InvalidTargetPrefab { get; private set; }
        [field: SerializeField] public CellManagerSO CellManager { get; private set; }
        [field: SerializeField] public UnitSelectionManagerSO UnitSelectionManager { get; private set; }

        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion 
        #region MonoBehaviour

        private void OnEnable()
        {
            if (SpawnedTargets == null) SpawnedTargets = new List<GameObject>();
        }

        #endregion
        #region Methods

        public void SpawnTargets()
        {
            foreach (var cell in CellManager.CellModelList)
            {
                if (cell == UnitSelectionManager.SelectedUnit.Model.UnitCellResidence) continue;

                if (cell.CellHasResidentUnit)
                {
                    SpawnedTargets.Add(Instantiate(InvalidTargetPrefab, cell.TransformPosition, Quaternion.identity));
                    continue;
                }
                
                SpawnedTargets.Add(Instantiate(ValidTargetPrefab, cell.TransformPosition, Quaternion.identity));
            }
        }

        public void DestroyTargets()
        {
            if (SpawnedTargets == null) return;

            foreach (var target in SpawnedTargets)
            {
                Destroy(target);
            }
            
            SpawnedTargets.Clear();
        }

        #endregion
    }
}
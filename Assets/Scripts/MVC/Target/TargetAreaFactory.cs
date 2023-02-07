using System;
using System.Collections.Generic;
using MVC.Ability;
using MVC.Unit;
using UnityEngine;

namespace MVC.Target
{
    public class TargetAreaFactory : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityController ability;
        [SerializeField] private UnitController sourceUnit;
        [SerializeField] private List<TargetAreaController> spawnedTargets;
        [SerializeField] private TargetAreaController validTargetPrefab;
        [SerializeField] private CellManagerSO cellManager;
        
        #endregion
        #region Events
        #endregion
        #region Properties

        public AbilityController Ability { get => ability; private set => ability = value; }
        public UnitController SourceUnit { get => sourceUnit; private set => sourceUnit = value; }
        public List<TargetAreaController> SpawnedTargets { get => spawnedTargets; private set => spawnedTargets = value; }
        public TargetAreaController ValidTargetPrefab { get => validTargetPrefab; private set => validTargetPrefab = value; }
        public CellManagerSO CellManager { get => cellManager; private set => cellManager = value; }

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
            if (SpawnedTargets == null) 
                SpawnedTargets = new List<TargetAreaController>();
        }

        #endregion
        #region Methods

        public void SpawnTargets()
        {
            foreach (var cell in CellManager.CellModelList)
            {
                int distance = Math.Abs(cell.CellGridPositionX - SourceUnit.Model.GridPositionX);
                
                if (distance > Ability.Model.Ability.MaximumRange) continue;
                if (distance < Ability.Model.Ability.MinimumRange) continue;
                if (cell.CellHasResidentUnit && !Ability.Model.Ability.CanTargetUnit) continue;
                if (cell.StaticData.CellIsLandDestination && !Ability.Model.Ability.CanTargetLand) continue;
                if (!cell.StaticData.CellIsLandDestination && cell.StaticData.CellIsAirDestination && !Ability.Model.Ability.CanTargetAir) continue;

                var targetArea = Instantiate(ValidTargetPrefab, cell.TransformPosition, Quaternion.identity);
                targetArea.Initialise(Ability.Model, SourceUnit.Model, cell);
                SpawnedTargets.Add(targetArea);
            }
        }

        public void DestroyTargets()
        {
            if (SpawnedTargets == null) return;

            foreach (var target in SpawnedTargets)
            {
                Destroy(target.gameObject);
            }
            
            SpawnedTargets.Clear();
        }

        #endregion
    }
}
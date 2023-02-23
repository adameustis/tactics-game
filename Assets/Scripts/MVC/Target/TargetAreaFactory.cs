using System;
using System.Collections.Generic;
using MVC.Ability;
using MVC.AbilityMenu;
using MVC.Cell;
using MVC.EventData;
using MVC.Unit;
using UnityEngine;

namespace MVC.Target
{
    public class TargetAreaFactory : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private List<TargetAreaController> spawnedTargets;
        [SerializeField] private RectTransform targetAreaContainer;
        [SerializeField] private TargetAreaController validTargetPrefab;
        [SerializeField] private TargetAreaController invalidTargetPrefab;
        [SerializeField] private CellManagerSO cellManager;
        
        #endregion
        #region Events
        #endregion
        #region Properties
        public List<TargetAreaController> SpawnedTargets { get => spawnedTargets; private set => spawnedTargets = value; }
        public RectTransform TargetAreaContainer { get => targetAreaContainer; set => targetAreaContainer = value; }
        public TargetAreaController ValidTargetPrefab { get => validTargetPrefab; private set => validTargetPrefab = value; }
        public TargetAreaController InvalidTargetPrefab { get => invalidTargetPrefab; private set => invalidTargetPrefab = value; }

        public CellManagerSO CellManager { get => cellManager; private set => cellManager = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers

        public void HandleOnEnterState(PlayerAndTransformData context)
        {
            
            // if (context.Tf.TryGetComponent(out AbilityMenuItemController abilityMenuItem))
            //     SpawnTargets(abilityMenuItem.Ability, abilityMenuItem.SourceUnit, abilityMenuItem.SourceCell);
            
            if(context is AbilityMenuItemData eventData)
                SpawnTargets(eventData);
        }
        
        public void HandleOnExitState(PlayerAndTransformData context)
        {
            DestroyTargets();
        }
        
        #endregion 
        #region MonoBehaviour

        private void OnEnable()
        {
            if (SpawnedTargets == null) 
                SpawnedTargets = new List<TargetAreaController>();
        }

        #endregion
        #region Methods

        public void SpawnTargets(AbilityMenuItemData data)
        {
            foreach (var cell in CellManager.CellModelList)
            {
                int distance = Math.Abs(cell.CellGridPositionX - data.SourceCell.CellResidentUnit.GridPositionX);

                bool validTarget = true;

                if (distance > data.Ability.Ability.MaximumRange) validTarget = false;
                else if (distance < data.Ability.Ability.MinimumRange) validTarget = false;
                else if (cell.CellHasResidentUnit && !data.Ability.Ability.CanTargetUnit) validTarget = false;
                else if (cell.StaticData.CellIsLandDestination && !data.Ability.Ability.CanTargetLand) validTarget = false;
                else if (!cell.StaticData.CellIsLandDestination && cell.StaticData.CellIsAirDestination && !data.Ability.Ability.CanTargetAir) validTarget = false;
                
                var targetArea = Instantiate(validTarget ? ValidTargetPrefab : InvalidTargetPrefab, TargetAreaContainer);
                targetArea.Initialise(data, cell);
                targetArea.gameObject.SetActive(true);
                SpawnedTargets.Add(targetArea);
            }
            SpawnedTargets[0].UIButton.Select();
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
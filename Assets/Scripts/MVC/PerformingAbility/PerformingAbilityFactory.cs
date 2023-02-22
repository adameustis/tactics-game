using MVC.Ability;
using MVC.Cell;
using MVC.EventData;
using MVC.Target;
using MVC.Unit;
using UnityEngine;

namespace MVC.PerformingAbility
{
    public class PerformingAbilityFactory : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private PerformingAbilityController spawnedPerformingAbility;

        #endregion
        #region Events
        #endregion
        #region Properties
        public PerformingAbilityController SpawnedPerformingAbility { get => spawnedPerformingAbility; private set => spawnedPerformingAbility = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        public void HandleOnEnterState(PlayerAndTransformEventData context)
        {
            if (context.Tf.TryGetComponent(out TargetAreaController targetArea))
                SpawnPerformingAbility(context.Player, targetArea.Ability, targetArea.SourceUnit, targetArea.SourceCell, targetArea.TargetCell);
        }
        
        public void HandleOnExitState(PlayerAndTransformEventData context)
        {
            DestroyPerformingAbility();
        }
        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        public void SpawnPerformingAbility(PlayerModel player, AbilityModel ability, UnitModel sourceUnit, CellModel sourceCell, CellModel targetCell)
        {
            SpawnedPerformingAbility = Instantiate(ability.Ability.PerformingPrefab, transform);
            SpawnedPerformingAbility.Initialise(player, ability, sourceUnit, sourceCell, targetCell);
            SpawnedPerformingAbility.gameObject.SetActive(true);
        }

        public void DestroyPerformingAbility()
        {
            if (SpawnedPerformingAbility == null) return;

            Destroy(SpawnedPerformingAbility.gameObject);
        }

        #endregion
    }
}
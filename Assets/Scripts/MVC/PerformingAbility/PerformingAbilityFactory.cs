using MVC.Ability;
using MVC.Cell;
using MVC.EventModel;
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
        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        public void SpawnPerformingAbility(PlayerAndTransformEventModel context)
        {
            var ability = context.Tf.GetComponent<AbilityController>().Model;
            var sourceUnit = context.Tf.GetComponent<UnitController>().Model;
            var destinationCell = context.Tf.GetComponent<CellController>().Model;

            SpawnedPerformingAbility = Instantiate(ability.Ability.PerformingPrefab, transform);
            SpawnedPerformingAbility.Initialise(context.Player, ability, sourceUnit, destinationCell);
        }

        public void DestroyPerformingAbility()
        {
            if (SpawnedPerformingAbility == null) return;

            Destroy(SpawnedPerformingAbility.gameObject);
        }

        #endregion
    }
}
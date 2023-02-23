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
        public void HandleOnEnterState(PlayerAndTransformData context)
        {
            // if (context.Tf.TryGetComponent(out TargetAreaController targetArea))
            //     SpawnPerformingAbility(context.Player, targetArea.Ability, targetArea.SourceUnit, targetArea.SourceCell, targetArea.TargetCell);
            
            if(context is TargetAreaData eventData)
                SpawnPerformingAbility(eventData);
        }
        
        public void HandleOnExitState(PlayerAndTransformData context)
        {
            DestroyPerformingAbility();
        }
        #endregion 
        #region MonoBehaviour
        #endregion
        #region Methods

        public void SpawnPerformingAbility(TargetAreaData data)
        {
            SpawnedPerformingAbility = Instantiate(data.Ability.Ability.PerformingPrefab, transform);
            SpawnedPerformingAbility.Initialise(data);
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
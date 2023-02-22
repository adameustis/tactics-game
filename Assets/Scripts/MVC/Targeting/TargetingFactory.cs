using System.Collections.Generic;
using MVC.Ability;
using MVC.EventData;
using UnityEngine;

namespace MVC.Targeting
{
    public class TargetingFactory : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public AbilityController SpawnedTargeting { get; private set; }

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

        public void SpawnTargeting(PlayerAndTransformEventData context)
        {
            if (!context.Tf.TryGetComponent(out AbilityController controller)) return;
            
            var targeting = Instantiate(controller.Model.Ability.TargetingPrefab, transform);
            targeting.Initialise(controller.Model);
            SpawnedTargeting = targeting;
        }

        public void DestroyTargeting(PlayerAndTransformEventData context)
        {
            if (SpawnedTargeting == null) return;
            
            Destroy(SpawnedTargeting.gameObject);
            SpawnedTargeting = null;
        }

        #endregion
    }
}
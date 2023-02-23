using System;
using System.Collections.Generic;
using MVC.Ability;
using MVC.Cell;
using MVC.EventData;
using UnityEngine;

namespace MVC.Target
{
    public class TargetFactory : MonoBehaviour
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
            if (SpawnedTargets != null) return;
            SpawnedTargets = new List<GameObject>();
        }

        #endregion
        #region Methods

        public void SpawnTargets(PlayerAndTransformData context)
        {
            if (!context.Tf.TryGetComponent(out CellController controller)) return;
            // work in progress
            // var target = Instantiate(ValidTargetPrefab, controller.transform.position, Quaternion.identity);
            // SpawnedTargets.Add(target);
        }

        public void DestroyTargets(PlayerAndTransformData context)
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
using MVC.Ability;
using MVC.EventData;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEvents;

namespace ScriptableObjects.Manager
{
    [CreateAssetMenu(fileName = "AbilitySelectionManagerSO", menuName = "ScriptableObjects/Manager/AbilitySelectionManagerSO")]
    [System.Serializable] public class AbilitySelectionManagerSO : ScriptableObject
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public AbilityModel SelectedAbility { get; private set; }
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> AbilityMenuItemInputSubmit { get; private set; }
        #endregion
        #region Event Subscriptions
        private void SubscribeToEvents() => AbilityMenuItemInputSubmit.UnityEvent.AddListener(AbilitySelectedStateHandler);
        private void UnsubscribeFromEvents() => AbilityMenuItemInputSubmit.UnityEvent.RemoveListener(AbilitySelectedStateHandler);

        #endregion
        #region Event Handlers

        public void AbilitySelectedStateHandler(PlayerAndTransformData context)
        {
            SelectedAbility = context.Tf.GetComponent<AbilityController>().Model;
        }
    
        #endregion
        #region Methods

        private void OnEnable() => SubscribeToEvents();
        private void OnDisable() => UnsubscribeFromEvents();

        #endregion
    }
}

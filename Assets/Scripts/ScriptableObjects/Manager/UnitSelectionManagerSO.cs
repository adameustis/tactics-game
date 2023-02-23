using MVC.EventData;
using MVC.Unit;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEvents;

namespace ScriptableObjects.Manager
{
    [CreateAssetMenu(fileName = "UnitSelectionManagerSO", menuName = "ScriptableObjects/Manager/UnitSelectionManagerSO")]
    [System.Serializable] public class UnitSelectionManagerSO : ScriptableObject
    {
        #region Properties
        [field: Header("Fields")]
        [field: SerializeField] public UnitController SelectedUnit { get; private set; }
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> UnitSelectedState { get; private set; }
        #endregion
        #region Event Subscriptions
        private void SubscribeToEvents() => UnitSelectedState.UnityEvent.AddListener(UnitSelectedStateHandler);
        private void UnsubscribeFromEvents() => UnitSelectedState.UnityEvent.RemoveListener(UnitSelectedStateHandler);

        #endregion
        #region Event Handlers

        public void UnitSelectedStateHandler(PlayerAndTransformData context)
        {
            SelectedUnit = context.Tf.GetComponent<UnitController>();
        }
    
        #endregion
        #region Methods

        private void OnEnable() => SubscribeToEvents();
        private void OnDisable() => UnsubscribeFromEvents();

        #endregion
    }
}

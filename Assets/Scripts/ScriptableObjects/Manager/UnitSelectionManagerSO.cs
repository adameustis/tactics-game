using MVC.EventData;
using MVC.SelectArea;
using MVC.Target;
using MVC.Unit;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEvents;

namespace ScriptableObjects.Manager
{
    [CreateAssetMenu(fileName = "UnitSelectionManagerSO", menuName = "ScriptableObjects/Manager/UnitSelectionManagerSO")]
    [System.Serializable] public class UnitSelectionManagerSO : ScriptableObject
    {
        #region Fields

        [Header("Fields")] 
        [SerializeField] private UnitModel selectedUnit;

        #endregion
        #region Events

        [Header("Events")] 
        [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> UnitSelectedState;

        #endregion
        #region Properties
        public UnitModel SelectedUnit { get => selectedUnit; private set => selectedUnit = value; }

        #endregion
        #region Event Properties
        public EventAbstractSO<UnityEventPlayerModelAndTransform> UnitSelectedState1 { get => UnitSelectedState; private set => UnitSelectedState = value; }

        #endregion
        #region Event Subscriptions
        private void SubscribeToEvents() => UnitSelectedState.UnityEvent.AddListener(UnitSelectedStateHandler);
        private void UnsubscribeFromEvents() => UnitSelectedState.UnityEvent.RemoveListener(UnitSelectedStateHandler);

        #endregion
        #region Event Handlers

        public void UnitSelectedStateHandler(PlayerAndTransformData context)
        {
            //SelectedUnit = context.Tf.GetComponent<UnitController>();
            
            if(context is SelectAreaData eventData)
                SelectedUnit = eventData.SourceCell.CellResidentUnit;
        }
    
        #endregion
        #region Methods

        private void OnEnable() => SubscribeToEvents();
        private void OnDisable() => UnsubscribeFromEvents();

        #endregion
    }
}

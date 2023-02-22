using MVC.Ability;
using MVC.EventData;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Unit
{
    public class UnitController : MonoBehaviour
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] private UnitModel model;

        #endregion
        #region Events
        #endregion
        #region Properties

        public UnitModel Model { get => model; set => model = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Event Subscriptions

        // public void SubscribeToEvents()
        // {
        //     Model.EventTransformPositionChanged.AddListener(HandleTransformPositionChanged);
        //     Model.EventUnitAbilityAdded.AddListener(HandleUnitAbilityAdded);
        //     Model.EventUnitAbilityRemoved.AddListener(HandleUnitAbilityRemoved);
        //     Model.EventUnitCanAirTraverseChanged.AddListener(HandleUnitCanAirTraverseChanged);
        //     Model.EventUnitCanLandTraverseChanged.AddListener(HandleUnitCanLandTraverseChanged);
        //     Model.EventUnitCanStopInAirChanged.AddListener(HandleUnitCanStopInAirChanged);
        //     Model.EventUnitCanStopOnLandChanged.AddListener(HandleUnitCanStopOnLandChanged);
        //     Model.EventUnitCellResidenceChanged.AddListener(HandleUnitCellResidenceChanged);
        //     Model.EventUnitEnergyUsedChanged.AddListener(HandleUnitDistanceTravelledChanged);
        //     Model.EventUnitHasCellResidenceChanged.AddListener(HandleUnitHasCellResidenceChanged);
        //     Model.EventUnitIconChanged.AddListener(HandleUnitIconChanged);
        //     Model.EventUnitNameChanged.AddListener(HandleUnitNameChanged);
        //     Model.EventUnitNumberChanged.AddListener(HandleUnitNumberChanged);
        //     Model.EventUnitOnTurnChanged.AddListener(HandleUnitOnTurnChanged);
        //     Model.EventUnitTurnWaitValueChanged.AddListener(HandleUnitTurnWaitValueChanged);
        // }

        // public void UnsubscribeFromEvents()
        // {
        //     Model.EventTransformPositionChanged.RemoveListener(HandleTransformPositionChanged);
        //     Model.EventUnitAbilityAdded.RemoveListener(HandleUnitAbilityAdded);
        //     Model.EventUnitAbilityRemoved.RemoveListener(HandleUnitAbilityRemoved);
        //     Model.EventUnitCanAirTraverseChanged.RemoveListener(HandleUnitCanAirTraverseChanged);
        //     Model.EventUnitCanLandTraverseChanged.RemoveListener(HandleUnitCanLandTraverseChanged);
        //     Model.EventUnitCanStopInAirChanged.RemoveListener(HandleUnitCanStopInAirChanged);
        //     Model.EventUnitCanStopOnLandChanged.RemoveListener(HandleUnitCanStopOnLandChanged);
        //     Model.EventUnitCellResidenceChanged.RemoveListener(HandleUnitCellResidenceChanged);
        //     Model.EventUnitEnergyUsedChanged.RemoveListener(HandleUnitDistanceTravelledChanged);
        //     Model.EventUnitHasCellResidenceChanged.RemoveListener(HandleUnitHasCellResidenceChanged);
        //     Model.EventUnitIconChanged.RemoveListener(HandleUnitIconChanged);
        //     Model.EventUnitNameChanged.RemoveListener(HandleUnitNameChanged);
        //     Model.EventUnitNumberChanged.RemoveListener(HandleUnitNumberChanged);
        //     Model.EventUnitOnTurnChanged.RemoveListener(HandleUnitOnTurnChanged);
        //     Model.EventUnitTurnWaitValueChanged.RemoveListener(HandleUnitTurnWaitValueChanged);
        // }

        #endregion
        #region Event Handlers

        // public void HandleTransformPositionChanged(Vector3 position) {}
        // public void HandleUnitNumberChanged() {}
        // public void HandleUnitNameChanged() {}
        // public void HandleUnitIconChanged() {}
        // public void HandleUnitAbilityAdded(AbilityModel ability) {}
        // public void HandleUnitAbilityRemoved(AbilityModel ability) {}
        // public void HandleUnitCanLandTraverseChanged() {}
        // public void HandleUnitCanAirTraverseChanged() {}
        // public void HandleUnitCanStopOnLandChanged() {}
        // public void HandleUnitCanStopInAirChanged() {}
        // public void HandleUnitHasCellResidenceChanged() {}
        // public void HandleUnitCellResidenceChanged() {}
        // public void HandleUnitOnTurnChanged() {}
        // public void HandleUnitTurnWaitValueChanged() {}
        // public void HandleUnitDistanceTravelledChanged() {}

        #endregion
        #region Monobehaviour
        #endregion
        #region Methods

        public void SetUnitBasedOnContextUnitController(PlayerAndTransformEventData context)
        {
            if (context.Tf.TryGetComponent(out UnitController controller))
                Model = controller.Model;
        }

        #endregion
    }
}

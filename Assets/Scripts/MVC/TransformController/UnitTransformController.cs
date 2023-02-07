using MVC.Unit;
using UnityEngine;

namespace MVC.TransformController
{
    public class UnitTransformController : Miscellaneous.TransformController
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] private UnitController unit;

        #endregion
        #region Properties

        public UnitController Unit { get => unit; private set => unit = value; }

        #endregion
        #region Event Subscriptions
        public void SubscribeToEvents()
        {
            Unit.Model.EventTransformPositionChanged.AddListener(SetTransformPosition);
        }

        public void UnsubscribeFromEvents()
        {
            Unit.Model.EventTransformPositionChanged.RemoveListener(SetTransformPosition);
        }
        #endregion
        #region Methods
        #endregion
    }
}
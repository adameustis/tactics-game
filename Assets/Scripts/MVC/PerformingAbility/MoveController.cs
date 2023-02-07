using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MVC.PerformingAbility
{
    public class MoveController : PerformAbilityController
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float minimumDistanceDifference = 0.001f;
        #endregion
        #region Events
        #endregion

        #region Properties
        public float Speed { get => speed; set => speed = value; }
        public float MinimumDistanceDifference { get => minimumDistanceDifference; set => minimumDistanceDifference = value; }

        #endregion

        #region Event Properties

        #endregion

        #region Event Subscriptions

        #endregion

        #region Event Handlers

        #endregion

        #region Monobehaviour

        private void Update()
        {
            // Move our position a step closer to the target.
            var step =  Speed * Time.deltaTime; // calculate distance to move
            var unit = SourceUnit.Model;
            var cell = DestinationCell.Model;
            
            unit.TransformPosition = Vector3.MoveTowards(unit.TransformPosition, cell.TransformPosition, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (!(Vector3.Distance(unit.TransformPosition, cell.TransformPosition) < MinimumDistanceDifference)) return;
            // Finalise
            unit.TransformPosition = cell.TransformPosition;
            unit.GridPositionX = cell.CellGridPositionX;
            unit.GridPositionY = cell.CellGridPositionY;
            OnComplete.Invoke();
            this.enabled = false;
        }

        #endregion

        #region Methods

        #endregion
    }
}

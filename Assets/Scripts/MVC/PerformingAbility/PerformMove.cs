using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MVC.PerformingAbility
{
    public class PerformMove : Perform
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
            var sourceUnit = Controller.Data.SourceUnit;
            var targetCell = Controller.Data.TargetCell;
            
            sourceUnit.TransformPosition = Vector3.MoveTowards(sourceUnit.TransformPosition, targetCell.TransformPosition, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (!(Vector3.Distance(sourceUnit.TransformPosition, targetCell.TransformPosition) < MinimumDistanceDifference)) return;
            // Finalise
            sourceUnit.TransformPosition = targetCell.TransformPosition;
            sourceUnit.GridPositionX = targetCell.CellGridPositionX;
            sourceUnit.GridPositionY = targetCell.CellGridPositionY;
            Controller.Data.SourceCell.CellResidentUnit = null;
            targetCell.CellResidentUnit = sourceUnit;
            OnComplete.Invoke();
            this.enabled = false;
        }

        #endregion

        #region Methods

        #endregion
    }
}

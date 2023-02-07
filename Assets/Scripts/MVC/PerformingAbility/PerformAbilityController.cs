using MVC.Ability;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.PerformingAbility
{
    public class PerformAbilityController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] protected AbilityController ability;
        [SerializeField] protected UnitController sourceUnit;
        [SerializeField] protected CellController destinationCell;

        #endregion
        #region Events

        [Header("Events")] 
        [SerializeField] protected UnityEvent onComplete;

        #endregion
        #region Properties

        public AbilityController Ability { get => ability; protected set => ability = value; }
        public UnitController SourceUnit { get => sourceUnit; protected set => sourceUnit = value; }
        public CellController DestinationCell { get => destinationCell; protected set => destinationCell = value; }

        #endregion

        #region Event Properties
        public UnityEvent OnComplete { get => onComplete; protected set => onComplete = value; }
        
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        #endregion
        #region Monobehaviour
        #endregion
        #region Methods
        #endregion
    }
}
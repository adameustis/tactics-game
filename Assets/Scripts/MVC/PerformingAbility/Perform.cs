using MVC.Ability;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.PerformingAbility
{
    public class Perform : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] protected PerformingAbilityController controller;

        #endregion
        #region Events

        [Header("Events")] 
        [SerializeField] protected UnityEvent onComplete;

        #endregion
        #region Properties

        public PerformingAbilityController Controller { get => controller; protected set => controller = value; }

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
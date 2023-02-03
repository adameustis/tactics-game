using MVC.EventModel;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.AbilityMenuItemDisplay
{
    public class UnusableAbilityInputSubmitHandler : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        [field: Header("Fields")]
        #endregion
        #region Event Properties
        [field: Header("Events")]
        [field: SerializeField] public EventPlayerModelAndTransformSO GenericEvent { get; private set; }
        [field: SerializeField] public UnityEvent LocalEvent { get; private set; }
        #endregion
        #region Monobehaviour
        #endregion
        #region Event Subscriptions
        #endregion
        #region Event Handlers
        
        public void HandleInputSubmit(PlayerAndTransformEventModel context)
        {
            if (!gameObject.activeSelf) return;
            
            GenericEvent.UnityEvent.Invoke(context);
            LocalEvent.Invoke();
        }
        
        #endregion
        #region Methods

        #endregion
    }
}
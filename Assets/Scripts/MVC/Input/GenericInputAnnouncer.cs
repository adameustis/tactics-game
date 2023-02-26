using MVC.EventData;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace MVC.Input
{
    public class GenericInputAnnouncer : MonoBehaviour
    {
        #region Fields

        [Header("Fields")]
        [SerializeField] private PlayerAndTransformData data;

        #endregion
        #region Events
        
        [Header("Events")] 
        [SerializeField] public EventPlayerModelAndTransformSO onInputCancel;
        [SerializeField] public EventPlayerModelAndTransformSO onInputMenu;

        #endregion
        #region Properties

        public PlayerAndTransformData Data { get => data; private set => data = value; }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO OnInputCancel { get => onInputCancel; private set => onInputCancel = value; }
        public EventPlayerModelAndTransformSO OnInputMenu { get => onInputMenu; private set => onInputMenu = value; }

        #endregion
        #region Monobehaviour
        #endregion
        #region Methods
        
        public void InvokeInputCancel(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            OnInputCancel.UnityEvent.Invoke(Data);
        }

        public void InvokeInputMenu(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            OnInputMenu.UnityEvent.Invoke(Data);
        }

        #endregion
    }
}
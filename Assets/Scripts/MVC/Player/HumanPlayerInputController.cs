using System.Linq;
using MVC.EventModel;
using MVC.Input;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEvents;

namespace MVC.Player
{
    [System.Serializable]
    public class HumanPlayerInputController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties

        [field: SerializeField] public PlayerController ThePlayer { get; private set; }
        //[field: SerializeField] public Controls View { get; private set; }
        
        [field: SerializeField] public PlayerPointer Pointer { get; private set; }

        #endregion
        #region Event Properties
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputCancelEvent { get; private set; }
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputDownEvent { get; private set; }
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputLeftEvent { get; private set; }
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputRightEvent { get; private set; }
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputSubmitEvent { get; private set; }
        [field: SerializeField] public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputUpEvent { get; private set; }
        #endregion
        #region MonoBehaviour
        #endregion
        #region Methods

        // private void OnDisable()
        // {
        //     UnsubscribeFromEvents();
        //     View.Player.Disable();
        // }

        // private void OnEnable()
        // {
        //     View = new Controls();
        //     SubscribeToEvents();
        //     View.Player.Enable();
        // }

        // private void SubscribeToEvents()
        // {
        //     View.Player.Cancel.performed += HandleInputCancel;
        //     View.Player.Down.performed += HandleInputDown;
        //     View.Player.Left.performed += HandleInputLeft;
        //     View.Player.Right.performed += HandleInputRight;
        //     View.Player.Submit.performed += HandleInputSubmit;
        //     View.Player.Up.performed += HandleInputUp;
        //     View.Player.Cancel.performed += HandleInput<InputCancel>;
        //     View.Player.Down.performed += HandleInput<InputDown>;
        //     View.Player.Left.performed += HandleInput<InputLeft>;
        //     View.Player.Right.performed += HandleInput<InputRight>;
        //     View.Player.Submit.performed += HandleInput<InputSubmit>;
        //     View.Player.Up.performed += HandleInput<InputUp>;
        // }

        // private void UnsubscribeFromEvents()
        // {
        //     View.Player.Cancel.performed -= HandleInputCancel;
        //     View.Player.Down.performed -= HandleInputDown;
        //     View.Player.Left.performed -= HandleInputLeft;
        //     View.Player.Right.performed -= HandleInputRight;
        //     View.Player.Submit.performed -= HandleInputSubmit;
        //     View.Player.Up.performed -= HandleInputUp;
        //     View.Player.Cancel.performed -= HandleInput<InputCancel>;
        //     View.Player.Down.performed -= HandleInput<InputDown>;
        //     View.Player.Left.performed -= HandleInput<InputLeft>;
        //     View.Player.Right.performed -= HandleInput<InputRight>;
        //     View.Player.Submit.performed -= HandleInput<InputSubmit>;
        //     View.Player.Up.performed -= HandleInput<InputUp>;
        // }

        public void HandleInputCancel(InputAction.CallbackContext context)
        {
            GenericInputCancelEvent.UnityEvent.Invoke(new PlayerAndTransformEventModel(ThePlayer.Model, null));
            HandleInput<InputCancel>(context);
        }

        public void HandleInputDown(InputAction.CallbackContext context)
        {
            GenericInputDownEvent.UnityEvent.Invoke(new PlayerAndTransformEventModel(ThePlayer.Model, null));
            HandleInput<InputDown>(context);
        } 

        public void HandleInputLeft(InputAction.CallbackContext context)
        {
            GenericInputLeftEvent.UnityEvent.Invoke(new PlayerAndTransformEventModel(ThePlayer.Model, null));
            HandleInput<InputLeft>(context);
        } 

        public void HandleInputRight(InputAction.CallbackContext context)
        {
            GenericInputRightEvent.UnityEvent.Invoke(new PlayerAndTransformEventModel(ThePlayer.Model, null));
            HandleInput<InputRight>(context);
        } 

        public void HandleInputSubmit(InputAction.CallbackContext context)
        {
            Debug.Log("Handling Input Submit");
            GenericInputSubmitEvent.UnityEvent.Invoke(new PlayerAndTransformEventModel(ThePlayer.Model, null));
            HandleInput<InputSubmit>(context);
        } 

        public void HandleInputUp(InputAction.CallbackContext context)
        {
            GenericInputUpEvent.UnityEvent.Invoke(new PlayerAndTransformEventModel(ThePlayer.Model, null));
            HandleInput<InputUp>(context);
        } 

        private void HandleInput<T>(InputAction.CallbackContext context) where T : Input.Input
        {
            foreach (var hit in Pointer.GetRayCastHits().Where(hit => hit.collider.enabled))
            {
                if (hit.transform.TryGetComponent(out T inputController))
                    inputController.InvokeInput(new PlayerAndTransformEventModel(ThePlayer.Model, inputController.transform));
            }
            // result.gameObject != null &&
            // UI
            foreach (var result in Pointer.GetUIRaycastHits().Where(result => result.gameObject.activeSelf))
            {
                if (result.gameObject.TryGetComponent(out T inputController))
                    inputController.InvokeInput(new PlayerAndTransformEventModel(ThePlayer.Model, inputController.transform));
            }
        }
        #endregion
    }
}

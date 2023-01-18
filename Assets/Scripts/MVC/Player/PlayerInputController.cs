using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerInputController : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerModel model; // This will need to come from somewhere in future
    [SerializeField] private Controls view;

    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputCancelEvent;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputDownEvent;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputLeftEvent;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputRightEvent;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputSubmitEvent;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericInputUpEvent;
    
    #endregion
    #region Properties

    public PlayerModel Model { get => model; set => model = value; }
    public Controls View { get => view; set => view = value; }

    #endregion
    #region Event Properties

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputCancelEvent
    {
        get => genericInputCancelEvent;
        set => genericInputCancelEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputDownEvent
    {
        get => genericInputDownEvent;
        set => genericInputDownEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputLeftEvent
    {
        get => genericInputLeftEvent;
        set => genericInputLeftEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputRightEvent
    {
        get => genericInputRightEvent;
        set => genericInputRightEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputSubmitEvent
    {
        get => genericInputSubmitEvent;
        set => genericInputSubmitEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericInputUpEvent
    {
        get => genericInputUpEvent;
        set => genericInputUpEvent = value;
    }

    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods

    public void OnDisable()
    {
        UnsubscribeFromActions();
        View.Player.Disable();
    }

    public void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        View = new Controls();
        SubscribeToActions();
        View.Player.Enable();
    }

    public void SubscribeToActions()
    {
        View.Player.Cancel.performed += HandleInputCancel;
        View.Player.Down.performed += HandleInputDown;
        View.Player.Left.performed += HandleInputLeft;
        View.Player.Right.performed += HandleInputRight;
        View.Player.Submit.performed += HandleInputSubmit;
        View.Player.Up.performed += HandleInputUp;
    }

    public void UnsubscribeFromActions()
    {
        View.Player.Cancel.performed -= HandleInputCancel;
        View.Player.Down.performed -= HandleInputDown;
        View.Player.Left.performed -= HandleInputLeft;
        View.Player.Right.performed -= HandleInputRight;
        View.Player.Submit.performed -= HandleInputSubmit;
        View.Player.Up.performed -= HandleInputUp;
    }

    public void HandleInputCancel(InputAction.CallbackContext context)
    {
        InputController hitController = GetTargetInputController();

        if (hitController == null)
        {
            // Cancel should be able to deselect current selection anytime, even if nothing valid underneath the mouse.
            GenericInputCancelEvent.UnityEvent.Invoke(new PlayerAndTransformEventModel(Model, null));
        }
        else
        {
            PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
            hitController.EventInputCancel.UnityEvent?.Invoke(eventModel);
            GenericInputCancelEvent.UnityEvent.Invoke(eventModel);        
        }
    }
    public void HandleInputDown(InputAction.CallbackContext context)
    {
        InputController hitController = GetTargetInputController();
        
        if (hitController == null)
            return;
        
        PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
        hitController.EventInputDown.UnityEvent?.Invoke(eventModel);
        GenericInputDownEvent.UnityEvent.Invoke(eventModel);
    }

    public void HandleInputLeft(InputAction.CallbackContext context)
    {
        InputController hitController = GetTargetInputController();
        
        if (hitController == null)
            return;
        
        PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
        hitController.EventInputLeft.UnityEvent?.Invoke(eventModel);
        GenericInputLeftEvent.UnityEvent.Invoke(eventModel);
    }

    public void HandleInputRight(InputAction.CallbackContext context)
        {
            InputController hitController = GetTargetInputController();
            
            if (hitController == null)
                return;
        
            PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
            hitController.EventInputRight.UnityEvent?.Invoke(eventModel);
            GenericInputRightEvent.UnityEvent.Invoke(eventModel);
        }

        public void HandleInputSubmit(InputAction.CallbackContext context)
        {
            InputController hitController = GetTargetInputController();
            
            if (hitController == null)
                return;
        
            PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
            hitController.EventInputSubmit.UnityEvent?.Invoke(eventModel);
            GenericInputSubmitEvent.UnityEvent.Invoke(eventModel);
        }

        public void HandleInputUp(InputAction.CallbackContext context)
        {
            InputController hitController = GetTargetInputController();
            
            if (hitController == null)
                return;
        
            PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
            hitController.EventInputUp.UnityEvent?.Invoke(eventModel);
            GenericInputUpEvent.UnityEvent.Invoke(eventModel);
        }

        public InputController GetTargetInputController()
        {
            if (Camera.main == null) return null;
            
            InputController hitController = null;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            //RaycastHit[] hits = Physics.RaycastAll(ray);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                hitController = hit.transform.GetComponent<InputController>();
            }

            return hitController;
        }
        

        #endregion
}

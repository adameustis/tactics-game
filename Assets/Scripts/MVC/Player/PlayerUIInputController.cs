using System;
using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerUIInputController : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerModel model; // This will need to come from somewhere in future
    [SerializeField] private Controls view;

    [SerializeField] GraphicRaycaster m_Raycaster;
    [SerializeField] PointerEventData m_PointerEventData;
    [SerializeField] MultiplayerEventSystem m_EventSystem;
    
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

    public GraphicRaycaster MRaycaster
    {
        get => m_Raycaster;
        set => m_Raycaster = value;
    }

    public PointerEventData MPointerEventData
    {
        get => m_PointerEventData;
        set => m_PointerEventData = value;
    }

    public MultiplayerEventSystem MEventSystem
    {
        get => m_EventSystem;
        set => m_EventSystem = value;
    }

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
    #region Event Handlers

    public void SceneLoadedHandler(Scene newScene, LoadSceneMode mode)
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        if (m_Raycaster == null)
            m_Raycaster = Array.Find(newScene.GetRootGameObjects(), x => x.name == "UI").GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        if (m_EventSystem == null)
            m_EventSystem = GetComponent<MultiplayerEventSystem>();
    }
    
    #endregion
    #region Event Subscriptions

    public void SubscribeToEvents()
    {
        SceneManager.sceneLoaded += SceneLoadedHandler;
    }
    
    public void UnsubscribeFromEvents()
    {
        SceneManager.sceneLoaded -= SceneLoadedHandler;
    }
    
    #endregion
    #region MonoBehaviour
    #endregion
    #region Methods

    public void OnDisable()
    {
        UnsubscribeFromActions();
        View.Player.Disable();
        UnsubscribeFromEvents();
    }

    public void OnEnable()
    {
        View = new Controls();
        SubscribeToActions();
        View.Player.Enable();
        SubscribeToEvents();
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
            return;
        
        PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
        hitController.EventInputCancel.UnityEvent?.Invoke(eventModel);
        GenericInputCancelEvent.UnityEvent.Invoke(eventModel);
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
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Mouse.current.position.ReadValue();

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);
            
            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                InputController hitController = result.gameObject.GetComponentInParent<InputController>();
                if (hitController != null)
                {
                    Debug.Log("Hit " + result.gameObject.name);
                    return hitController;
                }
            }

            return null;
        }

        #endregion
}

using System.Collections;
using System.Collections.Generic;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerMouseOverController : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerModel model; // This will need to come from somewhere in future
    [SerializeField] private Controls view;
    [SerializeField] private MouseOverController mouseOver;

    #endregion
    #region Events
    
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericMouseOnEvent;
    [SerializeField] private EventAbstractSO<UnityEventPlayerModelAndTransform> genericMouseOffEvent;
    
    #endregion
    #region Properties

    public PlayerModel Model { get => model; set => model = value; }
    public Controls View { get => view; set => view = value; }
    public MouseOverController MouseOver { get => mouseOver; set => mouseOver = value; }

    #endregion
    #region Event Properties

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericMouseOnEvent
    {
        get => genericMouseOnEvent;
        set => genericMouseOnEvent = value;
    }

    public EventAbstractSO<UnityEventPlayerModelAndTransform> GenericMouseOffEvent
    {
        get => genericMouseOffEvent;
        set => genericMouseOffEvent = value;
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
        View.Player.Cursor.performed += HandleInputCursor;
    }

    public void UnsubscribeFromActions()
    {
        View.Player.Cursor.performed -= HandleInputCursor;
    }
    
    public void HandleInputCursor(InputAction.CallbackContext context)
    {
        if (Camera.main == null) return;
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //RaycastHit[] hits = Physics.RaycastAll(ray);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Debug.Log(hit);
            MouseOverController hitController = hit.transform.GetComponent<MouseOverController>();
            if (hitController == null)
            {
                MouseOff();
            }
            else
            {
                MouseOn(hitController);
            }
        }
        else
        {
            MouseOff();
        }
    }

    public void MouseOff()
    {
        if (MouseOver == null) return;
        PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, MouseOver.transform);
        MouseOver.EventInputMouseOff.UnityEvent?.Invoke(eventModel);
        GenericMouseOffEvent.UnityEvent.Invoke(eventModel);
        MouseOver = null;
    }

    public void MouseOn(MouseOverController hitController)
    {
        if (MouseOver == hitController) return;
        MouseOff();
        MouseOver = hitController;
        PlayerAndTransformEventModel eventModel = new PlayerAndTransformEventModel(Model, hitController.transform);
        hitController.EventInputMouseOn.UnityEvent?.Invoke(eventModel);
        GenericMouseOnEvent.UnityEvent.Invoke(eventModel);
    }

    #endregion
}

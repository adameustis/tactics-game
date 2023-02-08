using System;
using System.Collections.Generic;
using System.Linq;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MVC.Player
{
    public class PlayerMouseOverController : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties

        [field: SerializeField] public PlayerController Player  { get; private set; }
        [field: SerializeField] public PlayerPointer Pointer { get; private set; }

        [field: SerializeField] public List<MouseOverController> MouseOverList { get; private set; } = new();
        [field: SerializeField] public List<MouseOverController> UIMouseOverList { get; private set; } = new();

        #endregion
        #region Event Properties
        #endregion
        #region MonoBehaviour
        #endregion
        #region Methods

        public void HandleCursorInput(InputAction.CallbackContext context)
        {
            RaycastHit[] raycastHits = Pointer.GetRayCastHits();
            
            List<MouseOverController> newMouseOverList = new();
            
            // Check for mouse over components to add to a new list
            foreach (var hit in raycastHits.Where(hit => hit.collider.enabled))
            {
                if (hit.transform.TryGetComponent(out MouseOverController mouseOverController))
                    newMouseOverList.Add(mouseOverController);
            }
            
            // Check if there are any existing mouse over components not in the new list
            foreach (var mouseOffController in MouseOverList.Except(newMouseOverList))
                MouseOff(mouseOffController, RemoveFromMouseOverList);

            // Check if there are any new list mouse over components not in the existing
            foreach (var mouseOnController in newMouseOverList.Except(MouseOverList))
                MouseOn(mouseOnController, RemoveFromMouseOverList);

            MouseOverList = newMouseOverList;
        }
        
        // UI
        public void HandleCursorInputUI(InputAction.CallbackContext context)
        {
            List<RaycastResult> uIRayCastResults = Pointer.GetUIRaycastHits();
            
            List<MouseOverController> newMouseOverList = new();

            // Check for mouse over components to add to a new list
            foreach (var result in uIRayCastResults.Where(result => result.gameObject.activeSelf))
            {
                if (result.gameObject.TryGetComponent(out MouseOverController mouseOverController))
                    newMouseOverList.Add(mouseOverController);
            }
            
            // Check if there are any existing mouse over components not in the new list
            foreach (var mouseOffController in UIMouseOverList.Except(newMouseOverList))
                MouseOff(mouseOffController, RemoveFromUIMouseOverList);

            // Check if there are any new list mouse over components not in the existing
            foreach (var mouseOnController in newMouseOverList.Except(UIMouseOverList))
                MouseOn(mouseOnController, RemoveFromUIMouseOverList);
            
            UIMouseOverList = newMouseOverList;
        }
        
        private void MouseOn(MouseOverController mouseOnController, UnityAction<MouseOverController> handleOnDisableMethod)
        {
            mouseOnController.InvokeMouseOn(new PlayerAndTransformEventModel(Player.Model, mouseOnController.transform));
            mouseOnController.OnDisabled.AddListener(handleOnDisableMethod);
        }
        
        private void MouseOff(MouseOverController mouseOffController, UnityAction<MouseOverController> handleOnDisableMethod)
        {
            mouseOffController.InvokeMouseOff(new PlayerAndTransformEventModel(Player.Model, mouseOffController.transform));
            mouseOffController.OnDisabled.RemoveListener(handleOnDisableMethod);
        }
        private void RemoveFromMouseOverList(MouseOverController controller)
        {
            MouseOverList.Remove(controller);
            MouseOff(controller, RemoveFromMouseOverList);
        }
        
        private void RemoveFromUIMouseOverList(MouseOverController controller)
        {
            UIMouseOverList.Remove(controller);
            MouseOff(controller, RemoveFromMouseOverList);
        }
        
        #endregion
    }
}
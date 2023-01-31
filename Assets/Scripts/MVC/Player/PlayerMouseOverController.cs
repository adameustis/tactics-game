using System.Collections.Generic;
using System.Linq;
using MVC.EventModel;
using ScriptableObjects.EventSO;
using UnityEngine;
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

        public void HandleRaycastHitsChanged(RaycastHit[] raycastHits)
        {
            List<MouseOverController> newMouseOverList = new();
            
            // Check for mouse over components to add to a new list
            foreach (var hit in raycastHits.Where(hit => hit.collider.enabled))
            {
                if (hit.transform.TryGetComponent(out MouseOverController mouseOverController))
                    newMouseOverList.Add(mouseOverController);
            }

            CheckForMouseOff(MouseOverList, newMouseOverList);
            CheckForMouseOn(MouseOverList, newMouseOverList);
            MouseOverList = newMouseOverList;
        }
        
        // UI
        public void HandleUIRaycastResultsChanged(List<RaycastResult> uIRayCastResults)
        {
            List<MouseOverController> newMouseOverList = new();

            // Check for mouse over components to add to a new list
            foreach (var result in uIRayCastResults.Where(result => result.gameObject.activeSelf))
            {
                if (result.gameObject.TryGetComponent(out MouseOverController mouseOverController))
                    newMouseOverList.Add(mouseOverController);
            }
            
            CheckForMouseOff(UIMouseOverList, newMouseOverList);
            CheckForMouseOn(UIMouseOverList, newMouseOverList);
            UIMouseOverList = newMouseOverList;
        }

        private void CheckForMouseOn(List<MouseOverController> existingList, List<MouseOverController> newList)
        {
            // Check if there are any new list mouse over components not in the existing
            foreach (var mouseOnController in newList.Except(existingList))
                MouseOn(mouseOnController);
        }
        
        private void CheckForMouseOff(List<MouseOverController> existingList, List<MouseOverController> newList)
        {
            // Check if there are any existing mouse over components not in the new list
            foreach (var mouseOffController in existingList.Except(newList)) 
                MouseOff(mouseOffController);
        }

        private void MouseOn(MouseOverController mouseOnController)
        {
            mouseOnController.EventInputMouseOn.UnityEvent.Invoke(new PlayerAndTransformEventModel(Player.Model, mouseOnController.transform));
        }

        private void MouseOff(MouseOverController mouseOffController)
        {
            mouseOffController.EventInputMouseOff.UnityEvent.Invoke(new PlayerAndTransformEventModel(Player.Model, mouseOffController.transform));
        }
        
        #endregion
    }
}
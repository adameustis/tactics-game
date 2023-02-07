using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MVC.Player
{
    public class PlayerPointer : MonoBehaviour
    {
        #region Fields
        #endregion
        #region Events
        #endregion
        #region Properties
        //[field: SerializeField] public bool MouseCanOverride { get; private set; }
        [field: SerializeField] public PointerEventData PointerData { get; private set; }
        [field: SerializeField] public MultiplayerEventSystem EventSystem { get; private set; }
        [field: SerializeField] public GraphicRaycaster Raycaster { get; private set; }
        //[field: SerializeField] public Controls Control { get; private set; }
        //[field: SerializeField] public RaycastHit[] RaycastHits { get; private set; }
        //[field: SerializeField] public List<RaycastResult> UIRaycastResults { get; private set; }
        [field: SerializeField] public Ray RayCastRay { get; private set; }
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public float RayMaxDistance { get; private set; } = 100f;
        [field: SerializeField] public LayerMask RayLayerMask { get; private set; }
        #endregion
        #region Event Properties
        [field: SerializeField] public UnityEvent<RaycastHit[]> OnRaycastHitsChanged { get; private set; }
        [field: SerializeField] public UnityEvent<List<RaycastResult>> OnUIRaycastResultsChanged { get; private set; }
        #endregion
        #region Event Handlers
        public void HandleInput(InputAction.CallbackContext context) => SetPointerPosition(Mouse.current.position.ReadValue());

        private void SceneLoadedHandler(Scene newScene, LoadSceneMode mode)
        {
            if (MainCamera == null) MainCamera = Camera.main;
            
            //Fetch the Raycaster from the GameObject (the Canvas)
            if (Raycaster == null) Raycaster = Array.Find(newScene.GetRootGameObjects(), x => x.name == "UI").GetComponent<GraphicRaycaster>();
            
            //Fetch the Event System from the Scene
            if (EventSystem == null) EventSystem = GetComponent<MultiplayerEventSystem>();
        }
        
        #endregion
        #region Event Subscriptions

        private void SubscribeToEvents()
        {
            SceneManager.sceneLoaded += SceneLoadedHandler;
            
            // if (!MouseCanOverride) return;
            // Control.Player.Cursor.performed += HandleInput;
        } 
        private void UnsubscribeFromEvents()
        {
            SceneManager.sceneLoaded += SceneLoadedHandler;
            
            // if (!MouseCanOverride) return;
            // Control.Player.Cursor.performed -= HandleInput;
        }

        #endregion
        #region MonoBehaviour

        private void OnEnable()
        {
            //Set up the new Pointer Event
            PointerData = new PointerEventData(EventSystem);
            
            //RaycastHits = Array.Empty<RaycastHit>();
            //UIRaycastResults = new List<RaycastResult>();
            //Control = new Controls();
            SubscribeToEvents();
            //Control.Player.Enable();
        }

        private void OnDisable()
        {
            UnsubscribeFromEvents();
            //Control.Player.Disable();
        }

        #endregion
        #region Methods

        public void SetPointerPosition(Vector2 newPointerPosition)
        {
            //if (PointerData.position == newPointerPosition) return;

            PointerData.position = newPointerPosition;
            // SetRaycastRay(MainCamera, PointerData);
            // SetRaycastHits(RayCastRay, RayMaxDistance, RayLayerMask);
            // SetUIRaycastHits(Raycaster, PointerData);
        }

        // private void SetRaycastRay(Camera setCamera, PointerEventData setPointerData)
        // {
        //     if (setCamera == null) return;
        //     RayCastRay = setCamera.ScreenPointToRay(PointerData.position);
        // }

        // private void SetRaycastHits(Ray setRay, float rayMaxDistance, LayerMask rayLayerMask)
        // {
        //     RaycastHit[] newRaycastHits = Physics.RaycastAll(setRay, rayMaxDistance, rayLayerMask);
        //     
        //     foreach (var hit in newRaycastHits)
        //     {
        //         Debug.Log(hit.transform.gameObject.name);
        //     }
        //     
        //     // Check if there hasn't been a change
        //     if (newRaycastHits.All(RaycastHits.Contains) && RaycastHits.All(newRaycastHits.Contains)) return;
        //
        //     RaycastHits = newRaycastHits;
        //     OnRaycastHitsChanged.Invoke(newRaycastHits);
        // }

        public RaycastHit[] GetRayCastHits()
        {
            RayCastRay = MainCamera.ScreenPointToRay(PointerData.position);

            return Physics.RaycastAll(RayCastRay, RayMaxDistance, RayLayerMask);
        }
        
        // private void SetUIRaycastHits(GraphicRaycaster setRaycaster, PointerEventData setPointerData)
        // {
        //     List<RaycastResult> newUIRaycastResults = new();
        //     
        //     //Raycast using the Graphics Raycaster and mouse click position
        //     setRaycaster.Raycast(setPointerData, newUIRaycastResults);
        //
        //     foreach (var hit in newUIRaycastResults)
        //     {
        //         Debug.Log(hit.gameObject.name);
        //     }
        //     
        //     // Check if there hasn't been a change
        //     if (newUIRaycastResults.All(UIRaycastResults.Contains) && UIRaycastResults.All(newUIRaycastResults.Contains)) return;
        //
        //     UIRaycastResults = newUIRaycastResults;
        //     OnUIRaycastResultsChanged.Invoke(newUIRaycastResults);
        // }
        
        public List<RaycastResult> GetUIRaycastHits()
        {
            List<RaycastResult> newUIRaycastResults = new();
            
            //Raycast using the Graphics Raycaster and mouse click position
            Raycaster.Raycast(PointerData, newUIRaycastResults);

            return newUIRaycastResults;
        }
        
        #endregion
    }
}
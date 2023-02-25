using MVC.AbilityMenu;
using MVC.SelectArea;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;

namespace MVC.EndTurn
{
    public class EndTurnOnClickNoWarning : EndTurnOnClick
    {
        #region Fields
        #endregion
        #region Events
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onMenuItemClicked;

        #endregion
        #region Properties
        #endregion
        #region Event Properties
        public EventPlayerModelAndTransformSO OnMenuItemClicked { get => onMenuItemClicked; private set => onMenuItemClicked = value; }

        #endregion
        #region Event Handlers
        #endregion
        #region Methods
        public override void InvokeMenuItemClicked(SelectAreaData setData) => OnMenuItemClicked.UnityEvent.Invoke(setData);
        
        #endregion
    }
}
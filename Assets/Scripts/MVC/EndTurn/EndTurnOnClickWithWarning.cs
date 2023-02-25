using MVC.SelectArea;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.EndTurn
{
    public class EndTurnOnClickWithWarning : EndTurnOnClick
    {
        #region Fields
        #endregion
        #region Events
        [Header("Events")]
        [SerializeField] private UnityEvent<SelectAreaData> onMenuItemClicked;
        #endregion
        #region Properties
        #endregion
        #region Event Properties
        public UnityEvent<SelectAreaData> OnMenuItemClicked { get => onMenuItemClicked; private set => onMenuItemClicked = value; }
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        public override void InvokeMenuItemClicked(SelectAreaData setData) => OnMenuItemClicked.Invoke(setData);


        #endregion
    }
}
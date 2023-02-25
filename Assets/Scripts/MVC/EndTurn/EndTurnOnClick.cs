using MVC.AbilityMenu;
using MVC.Image;
using MVC.SelectArea;
using MVC.Text;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;

namespace MVC.EndTurn
{
    public abstract class EndTurnOnClick : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] protected SelectAreaData data;
        #endregion
        #region Events
        #endregion
        #region Properties
        public SelectAreaData Data { get => data; private set => data = value; }
        #endregion
        #region Event Properties
        #endregion
        #region Event Handlers

        public void HandleOnClick() => InvokeMenuItemClicked(Data);

        #endregion
        #region Methods

        public void Initialise(SelectAreaData areaData) => Data = areaData;
        public abstract void InvokeMenuItemClicked(SelectAreaData setData);

        #endregion
    }
}
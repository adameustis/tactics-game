using MVC.AbilityMenu;
using MVC.Image;
using MVC.SelectArea;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.EndTurn
{
    public class EndTurnMenuItemController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private SelectAreaData data;
        [SerializeField] private Button uIButton;
        [SerializeField] private EndTurnOnClick onClickHandler;
        #endregion
        #region Events
        #endregion
        #region Properties
        public SelectAreaData Data { get => data; private set => data = value; }
        public Button UIButton { get => uIButton; private set => uIButton = value; }
        public EndTurnOnClick OnClickHandler { get => onClickHandler; private set => onClickHandler = value; }
        #endregion
        #region Event Properties
        #endregion
        #region Event Handlers
        #endregion
        #region Methods
        public void Initialise(SelectAreaData areaData)
        {
            Data = areaData;
            
            OnClickHandler.Initialise(areaData);
        }
        #endregion
    }
}
using MVC.Cell;
using MVC.EventData;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MVC.SelectArea
{
    public class SelectAreaController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private PlayerModel player;
        [SerializeField] private CellModel cell;
        [SerializeField] private Button uIButton;

        #endregion
        #region Fields
        [FormerlySerializedAs("onPerformingComplete")]
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onAreaClicked;

        #endregion
        #region Properties
        public PlayerModel Player { get => player; private set => player = value; }
        public CellModel Cell { get => cell; private set => cell = value; }
        public Button UIButton { get => uIButton; private set => uIButton = value; }

        #endregion
        #region Event Properties
        public EventPlayerModelAndTransformSO OnAreaClicked { get => onAreaClicked; private set => onAreaClicked = value; }

        #endregion
        #region Event Handlers

        public void HandleOnClick()
        {
            InvokeOnAreaClicked(Player, transform, Cell);
        }
        
        #endregion
        #region Methods

        public void Initialise(PlayerModel setPlayer, CellModel setCell)
        {
            Player = setPlayer;
            Cell = setCell;
        }
        
        public void InvokeOnAreaClicked(PlayerModel setPlayer, Transform setTransform, CellModel setCell)
        {
            OnAreaClicked.UnityEvent.Invoke(new SelectAreaEventData(setPlayer, setTransform, setCell));
        }
        
        #endregion
    }
}
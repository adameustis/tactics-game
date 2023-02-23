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
        [SerializeField] private SelectAreaData data;
        // [SerializeField] private PlayerModel player;
        // [SerializeField] private CellModel cell;
        [SerializeField] private Button uIButton;

        #endregion
        #region Events
        [FormerlySerializedAs("onPerformingComplete")]
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onAreaClicked;

        #endregion
        #region Properties
        public SelectAreaData Data { get => data; private set => data = value; }
        // public PlayerModel Player { get => player; private set => player = value; }
        // public CellModel Cell { get => cell; private set => cell = value; }
        public Button UIButton { get => uIButton; private set => uIButton = value; }

        #endregion
        #region Event Properties
        public EventPlayerModelAndTransformSO OnAreaClicked { get => onAreaClicked; private set => onAreaClicked = value; }

        #endregion
        #region Event Handlers

        public void HandleOnClick() => InvokeOnAreaClicked(Data);

        #endregion
        #region Methods

        public void Initialise(PlayerModel setPlayer, CellModel setSourceCell) => Data = new SelectAreaData(setPlayer, transform, setSourceCell);
        public void InvokeOnAreaClicked(SelectAreaData setData) => OnAreaClicked.UnityEvent.Invoke(setData);

        #endregion
    }
}
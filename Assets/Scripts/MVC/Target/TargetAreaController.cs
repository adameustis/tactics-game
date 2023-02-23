using MVC.Ability;
using MVC.AbilityMenu;
using MVC.Cell;
using MVC.Unit;
using ScriptableObjects.EventSO.EventPlayerModelAndTransformSO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MVC.Target
{
    public class TargetAreaController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private TargetAreaData data;
        // [SerializeField] private AbilityModel ability;
        // [FormerlySerializedAs("unit")] [SerializeField] private UnitModel sourceUnit;
        // [FormerlySerializedAs("unit")] [SerializeField] private CellModel sourceCell;
        // [FormerlySerializedAs("cell")] [SerializeField] private CellModel targetCell;
        [SerializeField] private Button uIButton;

        #endregion
        #region Events
        [Header("Events")]
        [SerializeField] private EventPlayerModelAndTransformSO onAreaClicked;

        #endregion
        #region Properties

        public TargetAreaData Data { get => data; private set => data = value; }
        // public AbilityModel Ability { get => ability; private set => ability = value; }
        // public UnitModel SourceUnit { get => sourceUnit; private set => sourceUnit = value; }
        //
        // public CellModel SourceCell { get => sourceCell; private set => sourceCell = value; }
        //
        // public CellModel TargetCell { get => targetCell; private set => targetCell = value; }
        public Button UIButton { get => uIButton; private set => uIButton = value; }

        #endregion
        #region Event Properties

        public EventPlayerModelAndTransformSO OnAreaClicked { get => onAreaClicked; private set => onAreaClicked = value; }

        #endregion
        #region Event Handlers

        public void HandleOnClick() => InvokeOnAreaClicked(Data);

        #endregion
        #region Methods

        public void Initialise(AbilityMenuItemData setData, CellModel setTargetCell)
        {
            Data = new TargetAreaData(setData.Player, transform, setData.SourceCell, setData.Ability, setTargetCell);
        }
        
        public void InvokeOnAreaClicked(TargetAreaData setData) => OnAreaClicked.UnityEvent.Invoke(setData);
        
        #endregion
    }
}
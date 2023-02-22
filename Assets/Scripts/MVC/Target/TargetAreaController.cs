using MVC.Ability;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MVC.Target
{
    public class TargetAreaController : MonoBehaviour
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityModel ability;
        [FormerlySerializedAs("unit")] [SerializeField] private UnitModel sourceUnit;
        [FormerlySerializedAs("unit")] [SerializeField] private CellModel sourceCell;
        [FormerlySerializedAs("cell")] [SerializeField] private CellModel targetCell;
        [SerializeField] private Button uIButton;

        #endregion
        #region Properties

        public AbilityModel Ability { get => ability; private set => ability = value; }
        public UnitModel SourceUnit { get => sourceUnit; private set => sourceUnit = value; }

        public CellModel SourceCell { get => sourceCell; private set => sourceCell = value; }

        public CellModel TargetCell { get => targetCell; private set => targetCell = value; }
        public Button UIButton { get => uIButton; private set => uIButton = value; }

        #endregion
        #region Methods

        public void Initialise(AbilityModel setAbility, UnitModel setSourceUnit, CellModel setSourceCell, CellModel setTargetCell)
        {
            Ability = setAbility;
            SourceUnit = setSourceUnit;
            SourceCell = setSourceCell;
            TargetCell = setTargetCell;
        }
        
        #endregion
    }
}
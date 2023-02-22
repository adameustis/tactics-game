using MVC.Cell;
using MVC.Unit;
using UnityEngine;

namespace MVC.EventData
{
    public class AbilityMenuItemEventData : PlayerAndTransformEventData
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityModel ability;
        [SerializeField] private UnitModel sourceUnit;
        [SerializeField] private CellModel sourceCell;

        #endregion
        #region Properties

        public AbilityModel Ability { get => ability; private set => ability = value; }
        public UnitModel SourceUnit { get => sourceUnit; private set => sourceUnit = value; }
        public CellModel SourceCell { get => sourceCell; set => sourceCell = value; }

        #endregion
        #region Constructors

        public AbilityMenuItemEventData(PlayerModel player, Transform tf, AbilityModel setAbility, UnitModel setSourceUnit, CellModel setSourceCell) : base(player, tf)
        {
            Ability = setAbility;
            SourceUnit = setSourceUnit;
            SourceCell = setSourceCell;
        }

        #endregion
    }
}
using System;
using MVC.Cell;
using MVC.Unit;
using UnityEngine;

namespace MVC.EventData
{
    [Serializable]
    public class PerformingAbilityEventData : PlayerAndTransformEventData
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private AbilityModel ability;
        [SerializeField] private UnitModel sourceUnit;
        [SerializeField] private CellModel sourceCell;
        [SerializeField] private CellModel targetCell;

        #endregion
        #region Properties

        public AbilityModel Ability { get => ability; private set => ability = value; }
        public UnitModel SourceUnit { get => sourceUnit; private set => sourceUnit = value; }
        public CellModel SourceCell { get => sourceCell; set => sourceCell = value; }
        public CellModel TargetCell { get => targetCell; private set => targetCell = value; }

        #endregion
        #region Constructors

        public PerformingAbilityEventData(PlayerModel player, Transform tf, AbilityModel setAbility, UnitModel setSourceUnit, CellModel setSourceCell, CellModel setTargetCell) : base(player, tf)
        {
            Ability = setAbility;
            SourceUnit = setSourceUnit;
            SourceCell = setSourceCell;
            TargetCell = setTargetCell;
        }

        #endregion
    }
}
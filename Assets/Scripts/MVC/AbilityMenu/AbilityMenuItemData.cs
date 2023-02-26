using MVC.Cell;
using MVC.EventData;
using MVC.SelectArea;
using MVC.Unit;
using UnityEngine;

namespace MVC.AbilityMenu
{
    [System.Serializable]
    public class AbilityMenuItemData : SelectAreaData
    {
        #region Fields
        [Header("AbilityMenuItemData Fields")]
        [SerializeField] protected AbilityModel ability;
        [SerializeField] protected UnitModel sourceUnit;

        #endregion
        #region Properties

        public AbilityModel Ability { get => ability; protected set => ability = value; }
        public UnitModel SourceUnit { get => sourceUnit; protected set => sourceUnit = value; }

        #endregion
        #region Constructors

        public AbilityMenuItemData(PlayerModel setPlayer, Transform setTf, CellModel setSourceCell, AbilityModel setAbility) : base(setPlayer, setTf, setSourceCell)
        {
            Ability = setAbility;
            SourceUnit = setSourceCell.CellResidentUnit;
        }

        #endregion
    }
}
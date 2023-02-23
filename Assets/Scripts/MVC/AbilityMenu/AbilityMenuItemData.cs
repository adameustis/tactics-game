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

        #endregion
        #region Properties

        public AbilityModel Ability { get => ability; protected set => ability = value; }

        #endregion
        #region Constructors

        public AbilityMenuItemData(PlayerModel setPlayer, Transform setTf, CellModel setSourceCell, AbilityModel setAbility) : base(setPlayer, setTf, setSourceCell)
        {
            Ability = setAbility;
        }

        #endregion
    }
}
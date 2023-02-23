using System;
using MVC.AbilityMenu;
using MVC.Cell;
using UnityEngine;

namespace MVC.Target
{
    [Serializable]
    public class TargetAreaData : AbilityMenuItemData
    {
    #region Fields
    [Header("TargetAreaData Fields")]
    [SerializeField] protected CellModel targetCell;

    #endregion
    #region Properties

    public CellModel TargetCell { get => targetCell; protected set => targetCell = value; }

    #endregion
    #region Constructors

    public TargetAreaData(PlayerModel setPlayer, Transform setTf, CellModel setSourceCell, AbilityModel setAbility, CellModel setTargetCell) : base(setPlayer, setTf, setSourceCell, setAbility)
    {
        TargetCell = setTargetCell;
    }

    #endregion
    }
}
using System;
using MVC.Cell;
using UnityEngine;

namespace MVC.EventData
{
    [Serializable]
    public class SelectAreaEventData : PlayerAndTransformEventData
    {
        #region Fields
        [Header("Fields")]
        [SerializeField] private CellModel sourceCell;

        #endregion
        #region Properties
        public CellModel SourceCell { get => sourceCell; set => sourceCell = value; }

        #endregion
        #region Constructors

        public SelectAreaEventData(PlayerModel player, Transform tf, CellModel setSourceCell) : base(player, tf)
        {
            SourceCell = setSourceCell;
        }

        #endregion
    }
}
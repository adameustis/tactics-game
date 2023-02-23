using System;
using MVC.Cell;
using MVC.EventData;
using UnityEngine;

namespace MVC.SelectArea
{
    [Serializable]
    public class SelectAreaData : PlayerAndTransformData
    {
        #region Fields
        [Header("SelectAreaData Fields")]
        [SerializeField] protected CellModel sourceCell;

        #endregion
        #region Properties
        public CellModel SourceCell { get => sourceCell; protected set => sourceCell = value; }

        #endregion
        #region Constructors

        public SelectAreaData(PlayerModel setPlayer, Transform setTf, CellModel setSourceCell) : base(setPlayer, setTf)
        {
            SourceCell = setSourceCell;
        }

        #endregion
    }
}
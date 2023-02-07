using System.Collections.Generic;
using MVC.Unit;
using ScriptableObjects.CellSO;
using UnityEngine;

namespace MVC.Cell
{
    [System.Serializable]
    public class CellModel
    {
        #region Delegates
        #endregion
        #region Fields

        [field: Header("Fields")]
        [SerializeField] private CellSO staticData;
        [SerializeField] private Vector3 transformPosition;
        [SerializeField] private int cellGridPositionX;
        [SerializeField] private int cellGridPositionY;
        [SerializeField] private bool cellHasResidentUnit;
        [System.NonSerialized] private UnitModel cellResidentUnit;
        //[System.NonSerialized] private List<CellModel> cellAdjacentCells;

        #endregion
        #region Events
        #endregion
        #region Properties
        public CellSO StaticData { get => staticData; private set => staticData = value; }
        public Vector3 TransformPosition { get => transformPosition; set => transformPosition = value; }
        public int CellGridPositionX { get => cellGridPositionX; set => cellGridPositionX = value; }
        public int CellGridPositionY { get => cellGridPositionY; set => cellGridPositionY = value; }
        public bool CellHasResidentUnit { get => cellHasResidentUnit; private set => cellHasResidentUnit = value; }
        public UnitModel CellResidentUnit
        {
            get => cellResidentUnit;
            set
            {
                CellHasResidentUnit = value != null;
                cellResidentUnit = value;
            }
        }
        //public List<CellModel> CellAdjacentCells { get => cellAdjacentCells; private set => cellAdjacentCells = value; }

        #endregion
        #region Event Properties
        #endregion
        #region Constructors
        #endregion
        #region Event Handlers
        #endregion
        #region Methods

        // public void AddAdjacentCell(CellModel cell)
        // {
        //     if (cell == null)
        //     {
        //         return;
        //     }
        //     CellAdjacentCells.Add(cell);
        // }

        // public void RemoveAdjacentCell(CellModel cell)
        // {
        //     if (cell == null)
        //     {
        //         return;
        //     }
        //     if (!CellAdjacentCells.Contains(cell))
        //     {
        //         return;
        //     }
        //     CellAdjacentCells.Remove(cell);
        // }

        #endregion
    }
}

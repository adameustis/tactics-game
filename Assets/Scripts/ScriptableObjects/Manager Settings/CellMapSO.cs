using System.Collections;
using System.Collections.Generic;
using MVC.Cell;
using UnityEngine;

[CreateAssetMenu(fileName = "CellMapSO", menuName = "ScriptableObjects/Settings/CellMapSO")]
[System.Serializable] public class CellMapSO : ScriptableObject
{
    #region Fields

    [Header("Values")]
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private CellController[] prefabArray;

    #endregion

    #region Properties

    public int GridWidth
    {
        get
        {
            return gridWidth;
        }
        set
        {
            gridWidth = value;
        }
    }

    public int GridHeight
    {
        get
        {
            return gridHeight;
        }
        set
        {
            gridHeight = value;
        }
    }

    public CellController[] PrefabArray
    {
        get
        {
            if(prefabArray == null)
            {
                prefabArray = new CellController[GridWidth * GridHeight];
            }
            return prefabArray;
        }
        set
        {
            prefabArray = value;
        }
    }

    #endregion

    #region Methods
    #endregion
}

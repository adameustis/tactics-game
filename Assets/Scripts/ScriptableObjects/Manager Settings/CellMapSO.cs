using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CellMapSO", menuName = "ScriptableObjects/Settings/CellMapSO")]
[System.Serializable] public class CellMapSO : ScriptableObject
{
    #region Fields

    [Header("Values")]
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private CellBattleController[] prefabArray;

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

    public CellBattleController[] PrefabArray
    {
        get
        {
            if(prefabArray == null)
            {
                prefabArray = new CellBattleController[GridWidth * GridHeight];
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

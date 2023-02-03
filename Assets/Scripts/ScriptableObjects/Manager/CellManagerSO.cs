using System.Collections;
using System.Collections.Generic;
using MVC.Cell;
using UnityEngine;

[CreateAssetMenu(fileName = "CellManagerSO", menuName = "ScriptableObjects/Manager/CellManagerSO")]
[System.Serializable] 
public class CellManagerSO : ScriptableObject
{
    #region Fields

    [Header("Fields")]
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private CellModel[] cellModelList;

    #endregion
    #region Events
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

    public CellModel[] CellModelList { get => cellModelList; private set => cellModelList = value; }

    #endregion
    #region Event Properties
    #endregion
    #region Methods

    public void OnAfterDeserialize()
    {
        Clear();
    }

    //public void OnEnable()
    //{

    //}

    //public void OnDestroy()
    //{

    //}

    public CellModel GetCellModel(int x, int y)
    {
        int listNumber = GridWidth * y + x;
        return CellModelList[listNumber];
    }

    public void SetCellModel(CellModel cell, int x, int y)
    {
        int listNumber = GridWidth * y + x;
        CellModelList[listNumber] = cell;
    }

    public void RemoveCellModel(int x, int y)
    {
        int listNumber = GridWidth * y + x;
        CellModelList[listNumber] = null;
    }

    public void RemoveCellBattleController(CellController controller)
    {
        if (controller == null) return;
        
        RemoveCellModel(controller.Model.CellGridPositionX, controller.Model.CellGridPositionY);
    }

    public void Clear()
    {
        GridWidth = 0;
        GridHeight = 0;
        CellModelList = null;
    }

    public void CreateBattleCells(CellMapSO cellMap)
    {
        Debug.Log("CellManagerSO - Create Cells");
        GridWidth = cellMap.GridWidth;
        GridHeight = cellMap.GridHeight;
        CellModelList = new CellModel[GridWidth * GridHeight];
        for (int x = 0; x < GridWidth; x++)
            for (int y = 0; y < GridHeight; y++)
                InstantiatePrefab(x, y, cellMap.PrefabArray[GridWidth * y + x]);
        
        // Set adjacent paths
        //CalculateAdjacentPaths();

    }

    public void InstantiatePrefab(int x, int y, CellController prefab)
    {
        Vector3 position = new Vector3((float)x, (float)y, 0.0f);
        CellController controller = Instantiate(prefab, position, Quaternion.identity);
        CellModel model = controller.Model;
        model.CellGridPositionX = x;
        model.CellGridPositionY = y;
        controller.transform.gameObject.name = model.StaticData.CellName + " " + x + "," + y;
        SetCellModel(model, x, y);
    }

    // public void CalculateAdjacentPaths()
    // {
    //     Debug.Log("CellManagerSO - CalculateAdjacentCells");
    //     int pathX;
    //     int pathY;
    //     foreach (CellModel cell in CellModelList)
    //     {
    //         pathX = cell.CellGridPositionX;
    //         pathY = cell.CellGridPositionY;
    //         //Check above
    //         if (pathY < GridHeight - 1)
    //         {
    //             cell.AddAdjacentCell(GetCellModel(pathX, pathY + 1));
    //         }
    //         //Check down
    //         if (pathY > 0)
    //         {
    //             cell.AddAdjacentCell(GetCellModel(pathX, pathY - 1));
    //         }
    //         //Check right
    //         if (pathX < GridWidth - 1)
    //         {
    //             cell.AddAdjacentCell(GetCellModel(pathX + 1, pathY));
    //         }
    //         //Check left
    //         if (pathX > 0)
    //         {
    //             cell.AddAdjacentCell(GetCellModel(pathX - 1, pathY));
    //         }
    //     }
    // }

    //public void Clear()
    //{
    //    Debug.Log("CellManagerSO - Destroy");
    //    foreach (CellController cell in Cells)
    //    {
    //        Destroy(cell.View.gameObject);
    //    }
    //}

    // public bool CheckIfTwoCellsAreAdjacent(int x1, int y1, int x2, int y2)
    // {
    //     bool isAdjacent = false;
    //
    //     if (x1 == x2 && y1 == y2 - 1) //Check above
    //     {
    //         isAdjacent = true;
    //
    //     }
    //     else if (x1 == x2 && y1 == y2 + 1) //Check down
    //     {
    //         isAdjacent = true;
    //     }
    //     else if (x1 == x2 - 1 && y1 == y2) //Check right
    //     {
    //         isAdjacent = true;
    //     }
    //     else if (x1 == x2 + 1 && y1 == y2) //Check left
    //     {
    //         isAdjacent = true;
    //     }
    //
    //     return isAdjacent;
    // }
    
    #endregion
}

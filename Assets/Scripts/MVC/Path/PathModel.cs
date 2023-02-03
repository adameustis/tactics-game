using System.Collections;
using System.Collections.Generic;
using MVC.Cell;
using UnityEngine;

public class PathModel : System.Object {

    #region Delegates
    #endregion
    #region Fields
    [SerializeField] private bool hasPath;
    [SerializeField] private bool canStop;
    [SerializeField] private bool canPassThrough;
    [SerializeField] private int pathLength;
    [System.NonSerialized] private List<PathModel> adjacentPaths;
    [System.NonSerialized] private Queue<PathModel> pathQueue;
    [SerializeField] private CellModel cell;
    #endregion
    #region Properties
    public bool HasPath
    {
        get
        {
            return hasPath;
        }

        set
        {
            hasPath = value;
        }
    }

    public bool CanStop { get => canStop; set => canStop = value; }
    public bool CanPassThrough { get => canPassThrough; set => canPassThrough = value; }

    public int PathLength
    {
        get
        {
            return pathLength;
        }

        set
        {
            pathLength = value;
        }
    }

    public List<PathModel> AdjacentPaths
    {
        get
        {
            return adjacentPaths;
        }

        set
        {
            adjacentPaths = value;
        }
    }

    public Queue<PathModel> PathQueue
    {
        get
        {
            return pathQueue;
        }

        set
        {
            if (value != null)
            {
                pathQueue = new Queue<PathModel>(value);
                if (value.Peek() != this)
                {
                    PathQueue.Enqueue(this);
                }
                HasPath = true;
                PathLength = PathQueue.Count;
            }
            else
            {
                pathQueue = null;
            }
        }
    }

    public CellModel Cell
    {
        get
        {
            return cell;
        }

        set
        {
            cell = value;
        }
    }

    #endregion
    #region Constructors
    public PathModel(CellModel setCellPathing)
    {
        Cell = setCellPathing;
    }
    #endregion
    #region MonoBehaviour
    #endregion
    #region Event Handlers
    #endregion
    #region Methods
    public void AddAdjacentPath(PathModel addPath)
    {
        if (addPath == null)
        {
            //Do nothing
        }
        else
        {
            if (AdjacentPaths == null)
            {
                AdjacentPaths = new List<PathModel>();
            }
            AdjacentPaths.Add(addPath);
        }
    }

    public void StartPath()
    {
        pathQueue = new Queue<PathModel>();
        pathQueue.Enqueue(this);
        HasPath = true;
        PathLength = PathQueue.Count;
    }

    public void ClearPath()
    {
        PathQueue = null;
        HasPath = false;
        CanPassThrough = false;
        PathLength = 0;
    }
    #endregion
}

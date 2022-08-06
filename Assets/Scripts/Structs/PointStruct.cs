using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PointStruct : IEquatable<PointStruct>
{
    #region Fields

    [SerializeField] private int x;
    [SerializeField] private int y;

    #endregion
    #region Properties

    public int X { get => x; private set => x = value; }
    public int Y { get => y; private set => y = value; }

    #endregion
    #region Constructors

    public PointStruct(int setX, int setY)
    {
        x = setX;
        y = setY;
    }

    #endregion
    #region Event Handlers
    #endregion
    #region Methods

    public void SetCoordinates(int setX, int setY)
    {
        X = setX;
        Y = setY;
    }

    public bool Equals(PointStruct other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
        return obj is PointStruct && Equals((PointStruct)obj);
    }

    public static bool operator ==(PointStruct object1, PointStruct object2)
    {
        return object1.Equals(object2);
    }
    public static bool operator !=(PointStruct object1, PointStruct object2)
    {
        return !object1.Equals(object2);
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public override string ToString()
    {
        return string.Format("{0},{1}", X, Y);
    }

    #endregion
}

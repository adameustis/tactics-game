using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeGrid<T> : ScriptableObject
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    public T[] Items = new T[0];

    public T Get(int x, int y)
    {
        int listNumber = x * width + y;
        return Items[listNumber];
    }

    public void Set(T thing, int x, int y)
    {
        int listNumber = x * width + y;
        Items[listNumber] = thing;
    }

    public void Remove(int x, int y)
    {
        int listNumber = x * width + y;
        Items[listNumber] = default(T);
    }
}

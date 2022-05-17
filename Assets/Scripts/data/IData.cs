using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData<T>
{
    public List<T> Settings { get; }
    public List<int> ChildrenSpawnChances { get; }
    public int MaxChildren { get; }

    public int MinChildren { get; }
}

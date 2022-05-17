using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreator<T1, T2> where T1 : class
{
    public T2 Create(int id, float x, float y, IOrbital parent, bool generateAll);
}

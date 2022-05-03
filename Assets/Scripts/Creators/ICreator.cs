using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreator<T1, T2> where T1 : class
{
    public T2 Create(float x, float y, float zoomFactor, Transform parent, bool generateAll);
}

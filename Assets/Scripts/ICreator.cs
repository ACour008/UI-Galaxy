using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreator<T> where T : class
{
    public void Create(float x, float y, Transform parent, T data, bool generateAll);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooler<T>
{
    public T Get(Transform parent);

    public void PutBack(T objectToAdd);
}

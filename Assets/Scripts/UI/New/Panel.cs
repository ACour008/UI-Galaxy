using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel: MonoBehaviour
{
    public abstract string id { get; }

    public abstract void SetActive(bool active);
    public abstract void Refresh(object payload = null);
}

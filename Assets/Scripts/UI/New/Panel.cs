using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel
{
    public string id { get; protected set; }

    public abstract void Activate();
    public abstract void Refresh();
}

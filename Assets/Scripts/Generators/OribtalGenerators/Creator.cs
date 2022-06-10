using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creator<T>
{
    protected DataManager dataManager;

    public Creator(DataManager dataManager)
    {
        this.dataManager = dataManager;

    }

    public virtual void CreateOrbitals(Orbital parent, GalaxyHash galaxyHash, bool discoveryMode)
    {
        return;
    }

    public virtual List<T> CreateOrbitals(Orbital parent, bool discoveryMode)
    {
        return null;
    }
}

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

    public virtual void CreateOrbitals(Orbital parent, GalaxyHash galaxyHash, OrbitalNameGenerator nameGenerator, bool discoveryMode)
    {
        return;
    }

    public virtual List<T> CreateOrbitals(Orbital parent, Government government, string name, bool discoveryMode)
    {
        return null;
    }
}

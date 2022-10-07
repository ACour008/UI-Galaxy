using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Government
{
    string name;
    int startingSystem;
    List<int> controlledSystems;

    public string Name { get => name; }

    public Government(string name, int startSystemID)
    {
        this.name = name;
        startingSystem = startSystemID;
        controlledSystems = new List<int>() { startSystemID };
    }
}

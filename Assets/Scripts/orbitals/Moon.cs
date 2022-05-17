using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Orbital, IOrbital
{
    public Transform Transform => this.transform;
    public void CreateOrbitals(OrbitalSettings setting, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {

    }

    public void Initialize(int id, OrbitalSettings setting, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {

    }
}

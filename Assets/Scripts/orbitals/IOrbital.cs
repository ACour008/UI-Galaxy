using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrbital
{
    public Transform Transform { get; }
    
    public void Initialize(int id, OrbitalSettings setting, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll);

    public void CreateOrbitals(OrbitalSettings setting, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll);
}

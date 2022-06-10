using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrbital
{ 
    public void Initialize(OrbitalSettings setting, Orbital parent, bool generateAll);

    public double Radius { get; }
    public double Mass { get; }
}

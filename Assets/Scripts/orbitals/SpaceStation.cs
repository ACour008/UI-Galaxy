using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : Orbital
{
    public override double Radius { get => solarRadius * Utils.RO_EARTH; }
    public override double Mass { get => solarMass * Utils.MO_EARTH; }

    public override void Initialize(OrbitalSettings setting, Orbital parent, bool generateAll)
    {
    }
}

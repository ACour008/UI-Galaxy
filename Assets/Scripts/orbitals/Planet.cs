using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Orbital
{
    private PlanetType type;

    private void Awake()
    {
        name = $"Planet_{LehmerRNG.Next(0, 10000)}";

        // find a way to make a biased distribution to the mid/lower end.
        // want a 1 trillion km solar system in there somewheres.
        orbitalDistance = LehmerRNG.NextDouble(3.5e7, 1e10);
    }
}
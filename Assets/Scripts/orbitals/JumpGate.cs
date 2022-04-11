using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGate: Orbital
{
    public double OrbitalDistance { get => orbitalDistance; }

    private void Awake()
    {
        name = "Jump Gate " + LehmerRNG.Next(0, 20);
        orbitalDistance = LehmerRNG.NextDouble(100e6, 300e6);
    }
}
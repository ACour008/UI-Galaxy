using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Orbital: OrbitalBase
{
    protected double temperature;
    protected double solarMass;
    protected double gravity;
    protected double density;
    protected double volume;
    protected double orbitalDistance;
    protected double orbitalPeriod;
    protected double rotationSpeed;
    public double OrbitalDistance { get => orbitalDistance; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Orbital: MonoBehaviour, IOrbital
{
    protected int id;
    [SerializeField] protected double age;
    [SerializeField] protected double solarRadius;
    [SerializeField] protected double temperature;
    [SerializeField] protected double solarMass;
    [SerializeField] protected double gravity;
    [SerializeField] protected double density;
    [SerializeField] protected double volume;
    [SerializeField] protected double orbitalDistance;
    [SerializeField] protected double orbitalPeriod;
    [SerializeField] protected double rotationSpeed;

    public double OrbitalDistance { get => orbitalDistance; }

    public abstract double Radius { get; }
    public abstract double Mass { get; }

    public abstract void Initialize(OrbitalSettings setting, Orbital parent, bool generateAll);

}

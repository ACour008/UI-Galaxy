using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Orbital
{
    private static int idAssigner = -1;
    private static double orbDistAssigner = 0;

    [SerializeField] private PlanetType type;
    [SerializeField] private float atmosphericPressure;
    [SerializeField] private double resources;
    private Orbital parent;
    private bool rings;

    private List<Moon> moons;
    private MoonCreator moonCreator;

    public List<Moon> Moons { get => moons; }

    public override double Radius { get => solarRadius * Utils.Conversions.RO_EARTH; }
    public override double Mass { get => solarMass * Utils.Conversions.MO_EARTH; }

    private void Awake()
    {
        moonCreator = CreatorFactory.GetCreatorFor<Moon>() as MoonCreator;
    }

    public override void Initialize(OrbitalSettings setting, Orbital parent, Government government, string name, bool generateAll)
    {
        PlanetSettings settings = setting as PlanetSettings;
        this.id = ++idAssigner;
        this.type = settings.type;
        this.parent = parent;
        this.resources = Utils.Conversions.DistributeRandomness(120000, 500000000, 20);

        this.age = Utils.Conversions.DistributeRandomness(setting.ageRange.min, setting.ageRange.max, 20);
        this.solarRadius = Utils.Conversions.DistributeRandomness(setting.solarRadiusRange.min, setting.solarRadiusRange.max, 20);
        this.solarMass = Utils.Conversions.DistributeRandomness(setting.solarMassRange.min, solarRadius * 1.05, 20);
        this.rotationSpeed = Utils.Conversions.DistributeRandomness(setting.rotationSpeedRange.min, setting.rotationSpeedRange.max, 20);

        double mass = solarMass * Utils.Conversions.MO_EARTH;
        double radius = solarRadius * Utils.Conversions.RO_EARTH * 1000;
        
        gravity = Utils.Conversions.GRAVITATIONAL_CONSTANT * (mass / Math.Pow(radius, 2));
        volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
        density = (mass / 100) / volume;

        orbDistAssigner += Utils.Conversions.DistributeRandomness(100000, 60000000, 20);
        orbitalDistance = orbDistAssigner;

        orbitalPeriod = Math.Sqrt((4 * Math.Pow(Math.PI, 2) * Math.Pow(radius, 3)) / Utils.Conversions.GRAVITATIONAL_CONSTANT * parent.Mass);

        // temp


        this.rings = (LehmerRNG.Next(0, 1) > 0.15) ? true : false;



        if (!generateAll) return;
        moons = moonCreator.CreateOrbitals(this, government, name, generateAll);
    }

    public static void ResetCounters()
    {
        idAssigner = -1;
        orbDistAssigner = 0;
    }
}
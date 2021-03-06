using System;
using System.Collections.Generic;
using UnityEngine;

public class Star : Orbital
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private static int IdAssigner = -1;

    [SerializeField] private SystemType type;
    [SerializeField] private double luminosity;

    private Orbital parent;
    private Color color;
    private List<Planet> planets;

    private PlanetCreator planetCreator;

    public Vector3 Position { get => transform.position; }
    public SystemType Type { get => type; }
    public List<Planet> Planets { get => planets; }
    public Color Color { get => color; }
    public override double Radius { get => solarRadius * Utils.MO_SUN; }
    public override double Mass { get => solarMass * Utils.MO_SUN; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        planetCreator = (PlanetCreator)CreatorFactory.GetCreatorFor<Planet>();
    }
    public override void Initialize(OrbitalSettings orbitalSettings, Orbital parent, bool generateAll)
    {
        StarSettings settings = orbitalSettings as StarSettings;
        StarSystem p = parent as StarSystem;

        this.id = ++Star.IdAssigner;
        this.type = settings.type;
        this.color = settings.color;
        this.parent = parent;

        name = $"Star_{id}";
        this.age = Utils.DistributeRandomness(settings.ageRange.min, settings.ageRange.max, 20);
        this.solarRadius = Utils.DistributeRandomness(settings.solarRadiusRange.min, settings.solarRadiusRange.max, 20);
        this.solarMass = Utils.DistributeRandomness(settings.solarMassRange.min, solarRadius * 1.05, 20);
        this.rotationSpeed = Utils.DistributeRandomness(settings.rotationSpeedRange.min, settings.rotationSpeedRange.max, 20);
        this.temperature = Utils.DistributeRandomness(settings.temperatureRange.min, settings.temperatureRange.max, 20);
        this.luminosity = Utils.DistributeRandomness(settings.luminosityInMagnitude.min, settings.luminosityInMagnitude.max, 20);

        double mass = solarMass * Utils.MO_SUN;
        double radius = solarRadius * Utils.RO_SUN * 1000;

        gravity = Utils.GRAVITATIONAL_CONSTANT * (mass / Math.Pow(radius, 2));
        volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
        density = (mass / 100) / volume;
        orbitalPeriod = 0;
        orbitalDistance = 0;

        if (!generateAll) return;
        planets = planetCreator.CreateOrbitals(this, generateAll);

        if (planets.Count > 0) p.SetRadius(planets[planets.Count - 1].OrbitalDistance);
    }

    public override string ToString() => name;

    public static void ResetCounters()
    {
        IdAssigner = -1;
    }
}
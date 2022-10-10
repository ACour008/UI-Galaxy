using System;
using System.Collections.Generic;
using UnityEngine;

public class Star : Orbital
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private static int IdAssigner = -1;

    [SerializeField] private StarType type;
    [SerializeField] private double luminosity;

    private Orbital parent;
    private Color color;
    private List<Planet> planets;
    private SpriteLoader spriteLoader;

    private PlanetCreator planetCreator;

    public Vector3 Position { get => transform.position; }
    public StarType Type { get => type; }
    public List<Planet> Planets { get => planets; }
    public Color Color { get => color; }
    public override double Radius { get => solarRadius * Utils.Conversions.RO_SUN; }
    public override double Mass { get => solarMass * Utils.Conversions.MO_SUN; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteLoader = GetComponent<SpriteLoader>();
        planetCreator = (PlanetCreator)CreatorFactory.GetCreatorFor<Planet>();
    }
    public override void Initialize(OrbitalSettings orbitalSettings, Orbital parent, Government government, string name, bool generateAll)
    {
        StarSettings settings = orbitalSettings as StarSettings;
        StarSystem p = parent as StarSystem;

        this.id = ++Star.IdAssigner;
        this.type = settings.type;
        this.color = settings.color;
        this.parent = parent;

        spriteRenderer.sprite = spriteLoader.LoadSprite((int)this.type);

        name = $"Star_{id}";
        this.angle = LehmerRNG.NextFloat(0, 360);
        this.age = Utils.Conversions.DistributeRandomness(settings.ageRange.min, settings.ageRange.max, 20);
        this.solarRadius = Utils.Conversions.DistributeRandomness(settings.solarRadiusRange.min, settings.solarRadiusRange.max, 20);
        this.solarMass = Utils.Conversions.DistributeRandomness(settings.solarMassRange.min, solarRadius * 1.05, 20);
        this.rotationSpeed = Utils.Conversions.DistributeRandomness(settings.rotationSpeedRange.min, settings.rotationSpeedRange.max, 20);
        this.temperature = Utils.Conversions.DistributeRandomness(settings.temperatureRange.min, settings.temperatureRange.max, 20);
        this.luminosity = Utils.Conversions.DistributeRandomness(settings.luminosityInMagnitude.min, settings.luminosityInMagnitude.max, 20);

        double mass = solarMass * Utils.Conversions.MO_SUN;
        double radius = solarRadius * Utils.Conversions.RO_SUN * 1000; // why this 1000 here?

        gravity = Utils.Conversions.GRAVITATIONAL_CONSTANT * (mass / Math.Pow(radius, 2));
        volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
        density = (mass / 100) / volume;
        orbitalPeriod = 0;
        orbitalDistance = (p.Type == SystemType.SINGLE) ? 0 : LehmerRNG.NextDouble(2.5e5, 3.6e9);

        if (!generateAll) return;
        planets = planetCreator.CreateOrbitals(this,government, name, generateAll);

        if (planets.Count > 0) p.SetRadius(planets[planets.Count - 1].OrbitalDistance);
    }

    public override string ToString() => name;

    public static void ResetCounters()
    {
        IdAssigner = -1;
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class Star : Orbital, IOrbital
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private SystemType type;
    private Color color;

    private double luminosity;
    private Vector3 localScale;

    private List<Planet> planets = new List<Planet>();
    private List<SpaceStation> stations = new List<SpaceStation>();

    private PlanetCreator planetCreator;
    private SpaceStationCreator stationCreator;
    private float prefabScale;

    public Transform Transform { get => this.transform; }
    public Vector3 Position { get => transform.position; }
    public float PrefabScale { get => prefabScale; }
    public SystemType Type { get => type; }
    public List<Planet> Planets { get => planets; }
    public Color Color { get => color; }

    private void Awake()
    {
        // spriteRenderer = GetComponent<SpriteRenderer>();
        planetCreator = (PlanetCreator)CreatorFactory.GetCreatorFor<Planet>();
        stationCreator = (SpaceStationCreator)CreatorFactory.GetCreatorFor<SpaceStation>();
    }

    public double ConfigOrbitalDistance(IOrbital parent)
    {
        StarSystem starSystem = parent.Transform.GetComponentInParent<StarSystem>();
        return (starSystem.Type == StarSystemType.SINGLE) ? 0 : LehmerRNG.NextDouble(1.5e9, 3.5e9);        
    }

    public void CreateOrbitals(OrbitalSettings setting, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        StarSettings settings = setting as StarSettings;

        int numPlanets = GetNumberOfPlanets(childrenProbabilities);
        int numStations = Mathf.Max(0, LehmerRNG.Next(-2, 1));
        int maxLimit = Mathf.Max(numPlanets, numStations);
        int planetCount = 0;
        int stationCount = 0;

        for (int i =0; i < maxLimit; i++)
        {
            if (planetCount < numPlanets)
            {
                Planet newPlanet = planetCreator.Create(i, 0, 0, this, generateAll);
                planets.Add(newPlanet);
                planetCount++;
            }

            if (stationCount < numStations)
            {
                SpaceStation newStation = stationCreator.Create(i, 0, 0, this, generateAll);
                stations.Add(newStation);
                stationCount++;
            }
        }
    }

    private int GetNumberOfPlanets(Dictionary<int, int> chances)
    {
        int total = 0;

        foreach(KeyValuePair<int, int> pair in chances)
        {
            total += chances[pair.Key];
        }

        foreach (KeyValuePair<int, int> pair in chances)
        {
            int chance = chances[pair.Key];
            bool chanceSucceeds = LehmerRNG.Next(0, total) < chance;

            if (chanceSucceeds)
            {
                return pair.Key;
            }

            total -= chance;
        }

        // failsafe.
        return 1;
    }

    public void Initialize(int id, OrbitalSettings orbitalSettings,  IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        StarSettings settings = orbitalSettings as StarSettings;
        
        this.id = id;
        this.type = settings.type;
        this.color = settings.color;
        this.prefabScale = LehmerRNG.NextFloat(settings.prefabScaleRange.min, settings.prefabScaleRange.max);

        name = $"Star_{id}";
        age = LehmerRNG.NextDouble(settings.ageRange.min, settings.ageRange.max);
        radius = LehmerRNG.NextDouble(settings.radiusRange.min, settings.radiusRange.max);
        solarMass = LehmerRNG.NextDouble(settings.solarMassRange.min, settings.solarMassRange.max);
        rotationSpeed = LehmerRNG.NextDouble(settings.rotationSpeedRange.min, settings.rotationSpeedRange.max);
        temperature = LehmerRNG.NextDouble(settings.temperatureRange.min, settings.temperatureRange.max);
        gravity = solarMass / Math.Pow(radius, 2);
        volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
        density = solarMass / volume;
        orbitalPeriod = 0;
        orbitalDistance = ConfigOrbitalDistance(parent);

        if (!generateAll) return;
        CreateOrbitals(settings, parent, childrenProbabilities, generateAll);
    }

    public override string ToString() => name;
}
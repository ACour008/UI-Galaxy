using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Orbital, IOrbital
{
    private PlanetType type;
    private float atmosphericPressure;
    private bool rings = false;

    private List<Moon> moons = new List<Moon>();
    private List<SpaceStation> spaceStations = new List<SpaceStation>();
    private MoonCreator moonCreator;
    private SpaceStationCreator stationCreator;

    public Transform Transform => this.transform;
    public int MoonCount { get => moons.Count; }
    public int PortCount { get => spaceStations.Count; }

    private void Awake()
    {
        moonCreator = (MoonCreator)CreatorFactory.GetCreatorFor<Moon>();
        stationCreator = (SpaceStationCreator)CreatorFactory.GetCreatorFor<SpaceStation>();
    }
    public void CreateOrbitals(OrbitalSettings orbitalSettings, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        PlanetSettings settings = orbitalSettings as PlanetSettings;

        int numMoons = GetNumberOfMoons(childrenProbabilities);
        int numPorts = (numMoons <= 1) ? Mathf.Max(0, LehmerRNG.Next(-2, 1)) : 0;
        
        int maxLimit = Mathf.Max(numMoons, numPorts);
        int moonCount = 0;
        int stationCount = 0;

        for(int i = 0; i < maxLimit; i++)
        {
            if (moonCount < numMoons)
            {
                Moon newMoon = moonCreator.Create(i, 0, 0, this, generateAll);
                moons.Add(newMoon);
                moonCount++;
            }

            if (stationCount < numPorts)
            {
                SpaceStation newStation = stationCreator.Create(i, 0, 0, this, generateAll);
                spaceStations.Add(newStation);
                stationCount++;
            }
        }
    }

    private int GetNumberOfMoons(Dictionary<int, int> spawnChances)
    {
        int total = 0;

        foreach (KeyValuePair<int, int> pair in spawnChances)
        {
            total += spawnChances[pair.Key];
        }

        foreach (KeyValuePair<int, int> pair in spawnChances)
        {
            int chance = spawnChances[pair.Key];
            bool chanceSucceeds = LehmerRNG.Next(0, total) < chance;
            if (chanceSucceeds)
            {
                return pair.Key;
            }

            total -= chance;
        }

        // failsafe
        return 1;
    }

    public void Initialize(int id, OrbitalSettings orbitalSettings, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        PlanetSettings settings = orbitalSettings as PlanetSettings;
        this.id = id;
        this.type = settings.type;

        if (!generateAll) return;

        CreateOrbitals(settings, parent, childrenProbabilities, generateAll);
    }
}
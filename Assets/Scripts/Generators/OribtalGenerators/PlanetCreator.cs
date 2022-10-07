using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreator : Creator<Planet>
{
    public PlanetCreator(DataManager dataManager):base(dataManager) { }

    public override List<Planet> CreateOrbitals(Orbital parent, Government government, string name, bool discoveryMode)
    {
        List<Planet> planets = new List<Planet>();

        int numPlanets = CalculateNumPlanets();

        Planet.ResetCounters();
        for (int i = 0; i < numPlanets; i++)
        {
            Planet newPlanet = Create(i, 0, 0, parent, government, name, discoveryMode);
            planets.Add(newPlanet);
        }

        return planets;
    }

    public Planet Create(int id, float x, float y, Orbital parent, Government government, string name, bool generateAll = false)
    {
        PlanetData data = dataManager.GetData<PlanetData>();

        float total = data.OrbitalSpawnChanceTotal;

        foreach (PlanetSettings setting in data.Settings)
        {
            float chance = setting.chanceOfSpawn;
            bool chanceOfSpawnSucceeding = LehmerRNG.NextDouble(0, total) < chance;

            if (chanceOfSpawnSucceeding)
            {
                Vector3 position = new Vector3(x, y, 0);
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, Vector3.zero, Quaternion.identity, parent.transform);
                gameObject.transform.localPosition = Vector3.zero;

                Planet newPlanet = gameObject.GetComponent<Planet>();

                newPlanet.Initialize(setting, parent, null, "", generateAll);
                gameObject.SetActive(false);

                return newPlanet;
            }

            total -= chance;
        }

        return null;
    }

    private int CalculateNumPlanets()
    {
        StarData data = dataManager.GetData<StarData>();
        float total = data.ChildrenSpawnChanceTotal;

        for(int i = 0; i < data.ChildrenSpawnChances.Count; i++)
        {
            float chance = data.ChildrenSpawnChances[i];
            bool chanceSucceeds = LehmerRNG.NextDouble(0f, total) < chance;

            if (chanceSucceeds)
            {
                return i + data.MinChildren;
            }
            else
            {
                total -= chance;
            }
        }

        return 0;
    }
}

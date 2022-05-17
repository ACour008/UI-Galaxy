using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreator : Creator, ICreator<PlanetData, Planet>
{
    public PlanetCreator(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public Planet Create(int id, float x, float y, IOrbital parent, bool generateAll = false)
    {
        PlanetData data = dataManager.GetData<PlanetData>();

        float total = 0;
        foreach (PlanetSettings setting in data.Settings)
        {
            total = setting.chanceOfSpawn;
        }

        foreach (PlanetSettings setting in data.Settings)
        {
            float chance = setting.chanceOfSpawn;
            bool chanceOfSpawnSucceeding = LehmerRNG.NextDouble(0, total) < chance;

            if (chanceOfSpawnSucceeding)
            {
                Vector3 position = new Vector3(x, y, 0);
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, parent.Transform);
                Planet newPlanet = gameObject.GetComponent<Planet>();
                Dictionary<int, int> childChances = CreateDictFrom(data.MinChildren, data.MaxChildren, data.ChildrenSpawnChances);

                newPlanet.Initialize(id, setting, parent, childChances, generateAll);
                gameObject.SetActive(false);

                return newPlanet;
            }

            total -= chance;
        }

        return null;
    }

    public Dictionary<int, int> CreateDictFrom(int min, int max, List<int> spawnChances)
    {
        Dictionary<int, int> chances = new Dictionary<int, int>();

        int curCount = min;
        for (int i = 0; i < spawnChances.Count && curCount < max; i++)
        {
            chances[curCount] = spawnChances[i];
            curCount++;
        }

        return chances;
    }
}

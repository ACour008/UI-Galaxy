using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemCreator : Creator, ICreator<StarSystemData, StarSystem>
{
    public StarSystemCreator(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public StarSystem Create(int id, float x, float y, IOrbital parent, bool generateAll=false)
    {
        bool starShouldExist = LehmerRNG.Next(0, 20) == 1;
        if (!starShouldExist) return null;

        StarSystemData data = dataManager.GetData<StarSystemData>();
        float total = 0;

        foreach(StarSystemSettings setting in data.Settings)
        {
            total += setting.chanceOfSpawn;
        }

        foreach (StarSystemSettings setting in data.Settings)
        {
            float chance = setting.chanceOfSpawn;
            bool chanceSucceeds = LehmerRNG.NextDouble(0f, total) < chance;

            if (chanceSucceeds)
            {
                Vector3 position = new Vector3(x, y, 0);
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, position, Quaternion.identity, parent.Transform);
                StarSystem newSystem = gameObject.GetComponent<StarSystem>();
                Dictionary<int, int> jumpGateChances = CreateDictFrom(data.MinChildren, data.MaxChildren, data.ChildrenSpawnChances);
                newSystem.Initialize(id, setting, parent, jumpGateChances, generateAll);

                return newSystem;

            }
            else
            {
                total -= chance;
            }

        }

        return null;
    }

    private Dictionary<int, int> CreateDictFrom(int min, int max, List<int> spawnChances)
    {
        Dictionary<int, int> chances = new Dictionary<int, int>();

        int curCount = min;
        for (int i = 0; i < spawnChances.Count; i++)
        {
            chances[curCount] = spawnChances[i];
            curCount++;
        }

        return chances;
    }
}

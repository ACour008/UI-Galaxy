using System.Collections.Generic;
using UnityEngine;

public class StarCreator : Creator, ICreator<StarData, Star>
{
    public StarCreator(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public Star Create(int id, float x, float y, IOrbital parent, bool generateAll = false)
    {
        StarData data = dataManager.GetData<StarData>();

        float total = 0;

        foreach(StarSettings setting in data.Settings)
        {
            total += setting.chanceOfSpawn;
        }

        foreach(StarSettings setting in data.Settings)
        {
            bool chanceofSpawningSucceeds = LehmerRNG.NextDouble(0f, total) < setting.chanceOfSpawn;

            if (chanceofSpawningSucceeds)
            {
                Vector3 position = new Vector3(x, y);
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, position, Quaternion.identity, parent.Transform);
                Star newStar = gameObject.GetComponent<Star>();
                Dictionary<int, int> planetSpawnChances = CreateDictFrom(data.MinChildren, data.MaxChildren, data.ChildrenSpawnChances);

                newStar.Initialize(id, setting, parent, planetSpawnChances, generateAll);
                
                
                gameObject.SetActive(false);
                return newStar;
            }
            else
            {
                total -= setting.chanceOfSpawn;
            }
        }
        return null;
    }
    public Dictionary<int, int> CreateDictFrom(int min, int max, List<int> spawnChances)
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
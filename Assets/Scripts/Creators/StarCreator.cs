using System.Collections;
using UnityEngine;

public class StarCreator : Creator, ICreator<StarData, Star>
{
    public StarCreator(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public Star Create(float x, float y, Transform parent, bool generateAll = false)
    {
        bool starShouldExist = LehmerRNG.Next(0, 21) == 1;
        if (!starShouldExist) {
            return null;
        }



        StarData data = dataManager.GetData<StarData>();
        float total = 0;

        foreach(StarSettings setting in data.Settings)
        {
            total += setting.chanceOfSpawn;
        }

        foreach(StarSettings setting in data.Settings)
        {
            float chance = setting.chanceOfSpawn;
            bool chanceSucceeds = LehmerRNG.NextDouble(0f, total) < chance;

            if (chanceSucceeds)
            {
                Vector3 position = new Vector3(x, y);
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, position, Quaternion.identity, parent);
                Star newStar = gameObject.GetComponent<Star>();
                
                newStar.Init(setting, generateAll);
                return newStar;
            }
            else
            {
                total -= chance;
            }
        }
        return null;
    }
}
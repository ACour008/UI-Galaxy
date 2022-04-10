using System.Collections;
using UnityEngine;

public class StarCreator : ICreator<StarData>
{
    public void Create(float x, float y, Transform parent, StarData data, bool generateAll = false)
    {
        bool starShouldExist = LehmerRNG.Next(0, 21) == 1;
        if (!starShouldExist) return;

        StarData d = data;
        float total = 0;

        foreach(StarSettings setting in d.Settings)
        {
            total += setting.chanceOfSpawn;
        }

        foreach(StarSettings setting in d.Settings)
        {
            Debug.Log($"{x}, {y}");

            float chance = setting.chanceOfSpawn;
            bool chanceSucceeds = LehmerRNG.NextDouble(0f, total) < chance;

            if (chanceSucceeds)
            {
                Vector3 position = new Vector3(x, y);
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, position, Quaternion.identity, parent);
                Star newStar = gameObject.GetComponent<Star>();
                
                newStar.Init(setting, generateAll);
                return;
            }
            else
            {
                total -= chance;
            }
        }


    }
}
using System.Collections.Generic;
using UnityEngine;

public class StarCreator : Creator<Star>
{
    public StarCreator(DataManager dataManager):base(dataManager)
    {
    }

    public override List<Star> CreateOrbitals(Orbital parent,  bool generateAll)
    {
        List<Star> stars = new List<Star>();

        int starLimit = (int)parent.GetComponent<StarSystem>().Type;
        Star.ResetCounters();
        for(int i = 0; i < starLimit; i++)
        {
            Star newStar = Create(parent, generateAll);
            stars.Add(newStar);
        }

        return stars;
    }

    public Star Create(Orbital parent, bool generateAll)
    {

        StarData data = dataManager.GetData<StarData>();
        float total = data.OrbitalSpawnChanceTotal; 

        foreach(StarSettings setting in data.Settings)
        {
            float chance = setting.chanceOfSpawn;
            bool chanceSucceeds = LehmerRNG.NextDouble(0f, total) < chance;

            if (chanceSucceeds)
            {
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, Vector3.zero, Quaternion.identity, parent.transform);
                gameObject.transform.localPosition = Vector3.zero;

                Star newStar = gameObject.GetComponent<Star>();

                newStar.Initialize(setting, parent, generateAll);
                gameObject.SetActive(false);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCreator : Creator<Moon>
{
    public MoonCreator(DataManager dataManager) : base(dataManager) { }

    public override List<Moon> CreateOrbitals(Orbital parent, bool generateAll)
    {
        List<Moon> moons = new List<Moon>();

        int numMoons = CalculateNumMoons();
        for(int i = 0; i < numMoons; i++)
        {
            Moon newMoon = Create(i, 0, 0, parent, generateAll);
            moons.Add(newMoon);
        }

        return moons;
    }

    public Moon Create(int id, float x, float y, Orbital parent, bool generateAll = false)
    {
        MoonData data = dataManager.GetData<MoonData>();

        Vector3 position = new Vector3(x, y, 0);
        GameObject gameObject = GameObject.Instantiate<GameObject>(data.Settings[0].prefab, parent.transform);
        Moon moon = gameObject.GetComponent<Moon>();
        //moon.Init();

        gameObject.SetActive(false);

        return moon;
    }

    private int CalculateNumMoons()
    {
        PlanetData data = dataManager.GetData<PlanetData>();
        float total = data.ChildrenSpawnChanceTotal;

        for (int i = 0; i < data.ChildrenSpawnChances.Count; i++)
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

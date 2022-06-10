using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemCreator : Creator<StarSystem>
{

    public StarSystemCreator(DataManager dataManager) : base(dataManager)
    {
    }

    public override void CreateOrbitals(Orbital parent, GalaxyHash galaxyHash, bool discoveryMode)
    {
        Dictionary<Vector3, bool> chosenPoints = new Dictionary<Vector3, bool>();
        float maxRadius = Mathf.Min(galaxyHash.Width, galaxyHash.Height);

        for (int i = 0; i < galaxyHash.Width * galaxyHash.Height; i++)
        {
            float radius = Mathf.Sqrt(LehmerRNG.NextFloat(0f, 1f)) * maxRadius;
            float angle = LehmerRNG.NextFloat(0, Mathf.PI * 2);

            int xPosition = (int)(Mathf.Cos(angle) * radius);
            int yPosition = (int)(Mathf.Sin(angle) * radius);

            Vector3 testPosition = new Vector3(xPosition, yPosition, 0);
            int repositionTry = 0;

            while (chosenPoints.ContainsKey(testPosition) && repositionTry < 20)
            {
                radius = Mathf.Sqrt(LehmerRNG.NextFloat(0f, 1f) * maxRadius);
                xPosition = (int)(Mathf.Cos(angle) * radius);
                yPosition = (int)(Mathf.Sin(angle) * radius);
                testPosition = new Vector3(xPosition, yPosition, 0);
                repositionTry++;
            }

            StarSystem starSystem = Create(i, xPosition, yPosition, parent, !discoveryMode);

            if (starSystem != null)
            {
                galaxyHash.Add(starSystem);
            }
        }
    }

    private StarSystem Create(int id, float x, float y, Orbital parent, bool generateAll=false)
    {
        bool starShouldExist = LehmerRNG.Next(0, 20) == 1;
        if (!starShouldExist) return null;

        StarSystemData data = dataManager.GetData<StarSystemData>();
        float total = data.OrbitalSpawnChanceTotal;

        foreach (StarSystemSettings setting in data.Settings)
        {
            float chance = setting.chanceOfSpawn;
            bool chanceSucceeds = LehmerRNG.NextDouble(0f, total) < chance;

            if (chanceSucceeds)
            {
                Vector3 position = new Vector3(x, y, 0);
                GameObject gameObject = GameObject.Instantiate<GameObject>(setting.prefab, position, Quaternion.identity, parent.transform);
                StarSystem newSystem = gameObject.GetComponent<StarSystem>();
                newSystem.Initialize(setting, parent, generateAll);

                return newSystem;

            }
            else
            {
                total -= chance;
            }

        }

        return null;
    }
}

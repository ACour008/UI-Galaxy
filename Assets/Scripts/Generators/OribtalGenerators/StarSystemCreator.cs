using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemCreator : Creator<StarSystem>
{
    private UISelector selector;

    public StarSystemCreator(DataManager dataManager, UISelector selector) : base(dataManager)
    {
        this.selector = selector;
    }

    public override void CreateOrbitals(Orbital parent, GalaxyHash galaxyHash, OrbitalNameGenerator nameGenerator, bool discoveryMode)
    {
        HashSet<Vector3> chosenPoints = new HashSet<Vector3>();
        float maxRadius = Mathf.Min(galaxyHash.Width, galaxyHash.Height);

        for (int i = 0; i < galaxyHash.Width * galaxyHash.Height; i++)
        {
            float radius = Mathf.Sqrt(LehmerRNG.NextFloat(0f, 1f)) * maxRadius;
            float angle = LehmerRNG.NextFloat(0, Mathf.PI * 2);

            int xPosition = (int)(Mathf.Cos(angle) * radius);
            int yPosition = (int)(Mathf.Sin(angle) * radius);

            Vector3 testPosition = new Vector3(xPosition, yPosition, 0);
            int repositionTry = 0;

            while (chosenPoints.Contains(testPosition) && repositionTry <= 15)
            {
                radius = Mathf.Sqrt(LehmerRNG.NextFloat(0f, 1f) * maxRadius);
                xPosition = (int)(Mathf.Cos(angle) * radius);
                yPosition = (int)(Mathf.Sin(angle) * radius);
                testPosition = new Vector3(xPosition, yPosition, 0);
                repositionTry++;
            }

            if (repositionTry >= 15) continue;

            chosenPoints.Add(testPosition);

            StarSystem starSystem = Create(i, xPosition, yPosition, parent, nameGenerator, !discoveryMode);

            if (starSystem != null)
            {
                starSystem.OnClicked += this.selector.Star_OnClicked;
                
                galaxyHash.Add(starSystem);
            }
        }
    }

    private StarSystem Create(int id, float x, float y, Orbital parent, OrbitalNameGenerator nameGenerator, bool generateAll=false)
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

                Government government = CreateGovernmentForSystemId(id);
                string name;

                if (government.Name == "Nswi Iskodeg") {
                    name = nameGenerator.GenerateStarSystemNameFor(Language.OJIBWE);
                }
                else {
                    name = $"StarSystem_{id}";
                }

                newSystem.Initialize(setting, parent, government, name, generateAll);

                return newSystem;

            }
            else
            {
                total -= chance;
            }

        }

        return null;
    }

        // For demo purposes;
    private Government CreateGovernmentForSystemId(int id)
    {
        float chance = LehmerRNG.NextFloat(0, 1);
        string govtName = (chance < 0.33) ? "Nswi Iskodeg" : (chance < 0.66) ? "Alien" : "URSS";

        return new Government(govtName, id);
    }
}

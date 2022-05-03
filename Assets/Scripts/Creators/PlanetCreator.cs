using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreator : Creator, ICreator<PlanetData, Planet>
{
    public PlanetCreator(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public Planet Create(float x, float y, float zoomFactor, Transform parent, bool generateAll)
    {
        PlanetData data = dataManager.GetData<PlanetData>();

        GameObject gameObject = GameObject.Instantiate<GameObject>(data.Settings[0].prefab, parent);
        Planet newPlanet = gameObject.GetComponent<Planet>();
        gameObject.SetActive(false);

        return newPlanet;
    }
}

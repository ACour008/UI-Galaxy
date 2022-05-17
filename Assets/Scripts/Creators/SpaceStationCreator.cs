using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationCreator : Creator, ICreator<SpaceStationData, SpaceStation>
{
    public SpaceStationCreator(DataManager manager)
    {
        this.dataManager = manager;
    }

    public SpaceStation Create(int id, float x, float y, IOrbital parent, bool generateAll = false)
    {
        SpaceStationData data = dataManager.GetData<SpaceStationData>();

        Vector3 position = new Vector3(x, y, 0);
        GameObject gameObject = GameObject.Instantiate<GameObject>(data.Settings[0].prefab, parent.Transform);
        SpaceStation newStation = gameObject.GetComponent<SpaceStation>();

        // newStation.Init();

        gameObject.SetActive(false);
        return newStation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationCreator : Creator<SpaceStation>
{
    public SpaceStationCreator(DataManager dataManager):base(dataManager)
    {
    }

    public override List<SpaceStation> CreateOrbitals(Orbital parent, bool discoveryMode)
    {
        return null;
    }

    public SpaceStation Create(int id, float x, float y, Orbital parent, bool generateAll = false)
    {
        SpaceStationData data = dataManager.GetData<SpaceStationData>();

        Vector3 position = new Vector3(x, y, 0);
        GameObject gameObject = GameObject.Instantiate<GameObject>(data.Settings[0].prefab, parent.transform);
        SpaceStation newStation = gameObject.GetComponent<SpaceStation>();

        // newStation.Init();

        gameObject.SetActive(false);
        return newStation;
    }
}

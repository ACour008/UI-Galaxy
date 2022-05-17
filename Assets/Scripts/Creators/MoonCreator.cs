using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCreator : Creator, ICreator<MoonData, Moon>
{
    public MoonCreator(DataManager manager)
    {
        this.dataManager = manager;
    }
    public Moon Create(int id, float x, float y, IOrbital parent, bool generateAll = false)
    {
        MoonData data = dataManager.GetData<MoonData>();

        Vector3 position = new Vector3(x, y, 0);
        GameObject gameObject = GameObject.Instantiate<GameObject>(data.Settings[0].prefab, parent.Transform);
        Moon moon = gameObject.GetComponent<Moon>();
        //moon.Init();

        gameObject.SetActive(false);

        return moon;
    }
}

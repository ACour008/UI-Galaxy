using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private ScriptableObject[] allData;

    public DataManager()
    {
        allData = Resources.LoadAll<ScriptableObject>("UniverseData");
    }

    public T GetData<T>() where T : class
    {
        foreach(var data in allData)
        {
            if (data.GetType() == typeof(T))
            {
                return data as T;
            } 
        }

        return default(T);
    }
}

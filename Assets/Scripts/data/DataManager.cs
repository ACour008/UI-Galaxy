using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private Dictionary<System.Type, OrbitalData> allData = new Dictionary<System.Type, OrbitalData>();

    public DataManager()
    {
        
        OrbitalData[] loadedData = Resources.LoadAll<OrbitalData>("UniverseData");

        for(int i = 0; i < loadedData.Length; i++)
        {
            OrbitalData data = loadedData[i];
            Type dataType = data.GetType();

            data.TotalSpawnChances();
            allData.Add(dataType, loadedData[i]);
        }
        

    }

    public T GetData<T>() where T : class
    {
        Type dataType = typeof(T);
        return allData[dataType] as T;
    }
}

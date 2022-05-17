using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GalaxyData", menuName = "Galaxy/StarData")]
public class StarData : ScriptableObject, IData<StarSettings>
{
    [SerializeField] private MinMax<int> planetCountRange;
    [SerializeField] private List<int> planetSpawnChances;
    [SerializeField] private List<StarSettings> settings;

    public List<StarSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get => planetSpawnChances; }
    public int MaxChildren { get => planetCountRange.max; }
    public int MinChildren { get => planetCountRange.min; }
}

[System.Serializable]
public class StarSettings: OrbitalSettings
{
    public GameObject prefab;
    public SystemType type;
    public Color color;
    public float chanceOfSpawn;
    public MinMax<double> temperatureRange;
    public MinMax<float> prefabScaleRange;
    public MinMax<float> luminosityInMagnitude;
}

[System.Serializable]
public struct MinMax<T>
{
    public T min;
    public T max;
}

public enum SystemType
{
    D = 0,
    M = 1,
    K = 2,
    G = 3,
    F = 4,
    A = 5,
    B = 6,
    O = 7
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GalaxyData", menuName = "Galaxy/StarData")]
public class StarData : OrbitalData
{
    [SerializeField] private MinMax<int> planetCountRange;
    [SerializeField] private List<int> planetSpawnChances;
    [SerializeField] private List<StarSettings> settings;
    private float childrenSpawnChances = 0;
    private float orbitalSpawnChances = 0;

    public List<StarSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get => planetSpawnChances; }
    public float ChildrenSpawnChanceTotal { get => childrenSpawnChances; }
    public float OrbitalSpawnChanceTotal { get => orbitalSpawnChances; }
    public int MaxChildren { get => planetCountRange.max; }
    public int MinChildren { get => planetCountRange.min; }

    public override void TotalSpawnChances()
    {
        orbitalSpawnChances = 0;
        childrenSpawnChances = 0;
        int spawnChancesLength = planetSpawnChances.Count;
        int settingsLength = settings.Count;
        int orbitalCount = 0;
        int childCount = 0;
        int limit = Mathf.Max(spawnChancesLength, settingsLength);

        for (int i = 0; i < limit; i++)
        {
            if (childCount < spawnChancesLength)
            {
                childrenSpawnChances += planetSpawnChances[i];
                childCount++;
            }
            if (orbitalCount < settingsLength)
            {
                orbitalSpawnChances += settings[i].chanceOfSpawn;
                orbitalCount++;
            }
        }
    }
}

[System.Serializable]
public class StarSettings: OrbitalSettings
{
    public GameObject prefab;
    public StarType type;
    public Color color;
    public float chanceOfSpawn;
    public MinMax<double> temperatureRange;
    public MinMax<float> luminosityInMagnitude;
}

[System.Serializable]
public struct MinMax<T>
{
    public T min;
    public T max;
}

public enum StarType
{
    // D = 0,
    M = 0,
    K = 1,
    G = 2,
    F = 3,
    A = 4,
    B = 5,
    O = 6
}
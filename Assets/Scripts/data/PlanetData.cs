using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet Info", menuName = "Galaxy/Planet Info")]
public class PlanetData : OrbitalData
{
    [SerializeField] private MinMax<int> moonCountRange;
    [SerializeField] private List<int> moonSpawnChances;
    [SerializeField] private List<PlanetSettings> settings;
    private float spawnChanceTotal;
    private float childChanceTotal;

    public List<PlanetSettings> Settings { get => settings; }
    public float OrbitalSpawnChanceTotal { get => spawnChanceTotal; }
    public float ChildrenSpawnChanceTotal { get => childChanceTotal; }
    public List<int> ChildrenSpawnChances { get => moonSpawnChances; }
    public int MaxChildren { get => moonCountRange.max; }
    public int MinChildren { get => moonCountRange.min; }

    public override void TotalSpawnChances()
    {
        spawnChanceTotal = 0;
        childChanceTotal = 0;
        int spawnCount = 0;
        int childCount = 0;
        int orbitalLength = settings.Count;
        int childLength = moonSpawnChances.Count;
        int limit = Mathf.Max(orbitalLength, childLength);

        for (int i = 0; i < limit; i++)
        {
            if (spawnCount < orbitalLength)
            {
                spawnChanceTotal += settings[i].chanceOfSpawn;
                spawnCount++;
            }

            if (childCount < childLength)
            {
                childChanceTotal += moonSpawnChances[i];
                childCount++;
            }
        }
    }
}

[System.Serializable]
public class PlanetSettings: OrbitalSettings
{
    public PlanetType type;
    public float chanceOfSpawn;
    public GameObject prefab;

    // will be many sprite variations
    public List<Sprite> planetSprites;
}

public enum PlanetType
{
    GAS_GIANT,
    NEPTUNIAN,
    SUPER_TERRESTRIAL,
    TERRESTRIAL
}

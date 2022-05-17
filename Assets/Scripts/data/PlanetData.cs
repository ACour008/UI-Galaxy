using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet Info", menuName = "Galaxy/Planet Info")]
public class PlanetData : ScriptableObject, IData<PlanetSettings>
{
    [SerializeField] private MinMax<int> moonCountRange;
    [SerializeField] private List<int> moonSpawnChances;
    [SerializeField] private List<PlanetSettings> settings;

    public List<PlanetSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get =>moonSpawnChances; }
    public int MaxChildren { get => moonCountRange.max; }
    public int MinChildren { get => moonCountRange.min; }
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

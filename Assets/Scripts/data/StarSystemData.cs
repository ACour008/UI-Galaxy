using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GalaxyData", menuName = "Galaxy/StarSystemData")]
public class StarSystemData : ScriptableObject
{
    [SerializeField] private MinMax<int> jumpGateCountRange;
    [SerializeField] private List<int> jumpGateSpawnChances;
    [SerializeField] private List<StarSystemSettings> settings;

    public List<StarSystemSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get => jumpGateSpawnChances; }
    public int MaxChildren { get => jumpGateCountRange.max; }
    public int MinChildren { get => jumpGateCountRange.min; }
}

[Serializable]
public class StarSystemSettings: OrbitalSettings
{ 
    public StarSystemType type;
    public float chanceOfSpawn;
    public GameObject prefab;
    public MinMax<float> prefabScaleRange;
    public MinMax<int> numJumpGates;
}

public enum StarSystemType
{
    SINGLE = 1,
    BINARY = 2,
    TRIARY = 3
}

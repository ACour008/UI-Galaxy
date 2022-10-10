using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GalaxyData", menuName = "Galaxy/StarSystemData")]
public class StarSystemData : OrbitalData
{
    [SerializeField] private MinMax<int> jumpGateCountRange;
    [SerializeField] private List<int> jumpgateSpawnChances;
    [SerializeField] private List<StarSystemSettings> settings;
    private float childrenSpawnChanceTotal = 0;
    private float orbitalSpawnChanceTotal = 0;

    public List<StarSystemSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get => jumpgateSpawnChances; }
    public float ChildrenSpawnChanceTotal { get => childrenSpawnChanceTotal; }
    public float OrbitalSpawnChanceTotal { get => orbitalSpawnChanceTotal; }
    public int MaxChildren { get => jumpGateCountRange.max; }
    public int MinChildren { get => jumpGateCountRange.min; }

    public override void TotalSpawnChances()
    {
        childrenSpawnChanceTotal = 0;
        orbitalSpawnChanceTotal = 0;

        for (int i = 0; i < jumpgateSpawnChances.Count; i++)
        {
            childrenSpawnChanceTotal += jumpgateSpawnChances[i];
        }

        foreach(StarSystemSettings setting in settings)
        {
            orbitalSpawnChanceTotal += setting.chanceOfSpawn;
        }

    }
}

[Serializable]
public class StarSystemSettings: OrbitalSettings
{ 
    public SystemType type;
    public float chanceOfSpawn;
    public GameObject prefab;
    public MinMax<float> prefabScaleRange;
    public MinMax<int> numJumpGates;
}

public enum SystemType
{
    SINGLE = 1,
    BINARY = 2,
    TRIARY = 3
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoonData", menuName = "Galaxy/MoonData")]
public class MoonData : OrbitalData
{
    [SerializeField] private List<MoonSettings> settings;
    float spawnChanceTotal;

    public List<MoonSettings> Settings { get => settings; }
    public float OrbitalSpawnChanceTotal { get => spawnChanceTotal; }
    public List<int> ChildrenSpawnChances { get => null; }
    public int MaxChildren { get => 0; }
    public int MinChildren { get => 0; }

    public override void TotalSpawnChances() { return; }
}

[System.Serializable]
public class MoonSettings: OrbitalSettings
{
    public GameObject prefab;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceStationData", menuName = "Galaxy/SpaceStationData")]
public class SpaceStationData : ScriptableObject, IData<SpaceStationSettings>
{
    [SerializeField] private List<SpaceStationSettings> settings;

    public List<SpaceStationSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get => null; }
    public int MaxChildren { get => 0; }
    public int MinChildren { get => 0; }
}

[System.Serializable]
public class SpaceStationSettings: OrbitalSettings
{
    public GameObject prefab;
}

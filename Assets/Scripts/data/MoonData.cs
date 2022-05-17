using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoonData", menuName = "Galaxy/MoonData")]
public class MoonData : ScriptableObject, IData<MoonSettings>
{
    [SerializeField] private List<MoonSettings> settings;

    public List<MoonSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get => null; }
    public int MaxChildren { get => 0; }
    public int MinChildren { get => 0; }
}

[System.Serializable]
public class MoonSettings: OrbitalSettings
{
    public GameObject prefab;
}

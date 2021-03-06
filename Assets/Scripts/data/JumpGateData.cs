using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Jumpgate Data", menuName = "Galaxy/Jumpgate Data")]
public class JumpGateData : ScriptableObject, IData<JumpgateSettings>
{
    [SerializeField] private List<JumpgateSettings> settings;

    public List<JumpgateSettings> Settings { get => settings; }
    public List<int> ChildrenSpawnChances { get => null; }
    public int MaxChildren { get => 0; }
    public int MinChildren { get => 0; }
}

[System.Serializable]
public struct JumpgateSettings
{
    public JumpgateType type;
    public float chanceOfSpawn;
    public GameObject prefab;
}

[System.Serializable]
public enum JumpgateType
{
    PORTAL,
    RUNNER
}

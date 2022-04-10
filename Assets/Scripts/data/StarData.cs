using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GalaxyData", menuName = "Galaxy/StarSystemData")]
public class StarData : ScriptableObject, IData<StarSettings>
{
    [SerializeField] private List<StarSettings> settings;

    public List<StarSettings> Settings { get => settings; }
}


[System.Serializable]
public struct StarSettings
{
    public GameObject prefab;
    public SystemType type;
    public Color color;
    public float chanceOfSpawn;
    public MinMax<float> prefabScaleRange;
    public MinMax<double> radiusRange;
    public MinMax<double> ageRange;
    public MinMax<double> tempRangeInK;
    public MinMax<double> massInKG;
    public MinMax<float> luminosityInMagnitude;
    public MinMax<int> numJumpgates;

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
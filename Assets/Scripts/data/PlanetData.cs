using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet Info", menuName = "Galaxy/Planet Info")]
public class PlanetData : ScriptableObject, IData<PlanetSettings>
{
    [SerializeField] private List<PlanetSettings> settings;

    public List<PlanetSettings> Settings { get => settings; }
}

[System.Serializable]
public struct PlanetSettings
{
    public PlanetType type;
    public MinMax<double> radiusRange;
    public MinMax<double> ageRange;
    public MinMax<double> temperatureRangeInC;
    public MinMax<double> massRange;
    public MinMax<double> distanceFromSuninKM;
}

public enum PlanetType
{
    ASTEROIDAL,
    MERCURIAN,
    SUBTERRAN,
    TERRAN,
    SUPERTERRAN,
    NEPTUNIAN,
    JOVIAN
}

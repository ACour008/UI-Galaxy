using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolarPropertiesComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI systemType;
    [SerializeField] private TextMeshProUGUI jumpGateCount;
    [SerializeField] private TextMeshProUGUI age;
    [SerializeField] private TextMeshProUGUI solarRadius;

    public void SetData(StarSystem starSystem) 
    {
        this.systemType.text = starSystem.Type.ToString();
        this.jumpGateCount.text = starSystem.JumpGateCount.ToString();
        this.age.text = Utils.Conversions.ConvertNumber(starSystem.Age, 1e9);

        this.solarRadius.text = string.Format("{0:0.##}", Utils.Conversions.ConvertKmToAu(starSystem.Radius));
    }
}

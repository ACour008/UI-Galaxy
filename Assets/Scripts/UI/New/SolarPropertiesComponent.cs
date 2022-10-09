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

    public void SetData(StarSystem star) 
    {
        this.systemType.text = star.Type.ToString();
        this.jumpGateCount.text = star.JumpGateCount.ToString();
        this.age.text = Utils.Conversions.ConvertNumber(star.Age, 1e9);
        this.solarRadius.text = star.Radius.ToString();
    }
}

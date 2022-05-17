using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI typeText;
    [SerializeField] private TextMeshProUGUI planetsText;
    [SerializeField] private TextMeshProUGUI jumpGatesText;

    [SerializeField] private SystemInfoTable table;

    public void Start()
    {
        ClearAll();
    }

    public void Star_OnClicked(object sender, OnStarSystemClickEventArgs eventArgs)
    {
        StarSystem system = eventArgs.system;

        nameText.text = system.name;
        typeText.text = "Star Type: " + system.Type.ToString();
        // planetsText.text = "Planets: " + system.Star.Planets.Count.ToString();

        table.Create(system);
    }

    public void ClearAll()
    {
        nameText.text = "-";
        typeText.text = "Star Type: -";
        planetsText.text = "Planets: -";
        jumpGatesText.text = "Jump gates: -";

        table.Clear();
    }


}

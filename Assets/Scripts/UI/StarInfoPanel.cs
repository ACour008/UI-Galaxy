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

    public void Star_OnClicked(object sender, System.EventArgs e)
    {
        OnStarClickEventArgs arg = e as OnStarClickEventArgs;
        Star star = arg.star;

        nameText.text = star.name;
        typeText.text = "Star Type: " + star.Type.ToString();
        planetsText.text = "Planets: " + star.PlanetCount.ToString();
        jumpGatesText.text = "Jump gates: " + star.JumpGateCount.ToString();

        table.Create(star);
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

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableEntry : MonoBehaviour
{
    // TODO: Set up on click event for selection.

    [SerializeField] private Image selectionField;
    [SerializeField] private Image typeField;
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TextMeshProUGUI distanceField;

    [SerializeField] private Image selectedImage;

    private void Awake()
    {
        selectionField = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        typeField = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        nameField = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        distanceField = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    public TableEntry SetRow(string name, double distance)
    {
        nameField.text = name;
        distanceField.text = (distance == 0) ? "-" : Utils.ConvertKm(distance);

        return this;
    }

    public void ClearAll()
    {
        nameField.text = "";
        distanceField.text = "";
    }

    private void OnDisable()
    {
        ClearAll();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolarDataHUD : MonoBehaviour
{
    [Header("Positioning")]
    [SerializeField] Vector3 offset;

    [Header("Data")]
    [SerializeField] TextMeshProUGUI starName;
    [SerializeField] TextMeshProUGUI government;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetDataFrom(StarSystem starSystem)
    {
        this.starName.text = starSystem.name;
        government.text = starSystem.Government;
    }

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition + offset;
    }
}

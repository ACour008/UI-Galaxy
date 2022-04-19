using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class SystemInfoTable : MonoBehaviour
{
    [SerializeField] private RectTransform viewport;
    [SerializeField] private RectTransform content;
    [SerializeField] private RectTransform tableHeader;
    [SerializeField] private TableEntry tableEntryTemplate;

    private float rowHeight;
    private float currentPositionY;
    private float viewportHeight;
    [SerializeField] private GameObjectPooler pooler;
    private List<GameObject> currentRows = new List<GameObject>();

    public void Clear()
    {
        currentPositionY = tableHeader.anchoredPosition.y - rowHeight;
        foreach (GameObject row in currentRows)
        {
            pooler.PutBack(row);
        }

        currentRows.Clear();
    }

    public void Create(Star star)
    {
        Clear();

        CreateTableRow(star, currentPositionY);
        currentPositionY -= rowHeight;

        for (int p = 0; p < star.PlanetCount; p++)
        {
            CreateTableRow(star.Planets[p], currentPositionY, "  ");
            currentPositionY -= rowHeight;

            // Do moons.
        }

        for (int j = 0; j < star.JumpGateCount; j++)
        {
            CreateTableRow(star.JumpGates[j], currentPositionY, "  ");
            currentPositionY -= rowHeight;
        }

        SetTableContentHeight(); // own class prob;
    }

    private void CreateTableRow(Orbital orbital, float yPosition, string prefix="")
    {
        GameObject go = pooler.Get(content.transform);

        RectTransform rect = go.GetComponent<RectTransform>();
        TableEntry entry = go.GetComponent<TableEntry>();

        rect.anchoredPosition = new Vector2(0, yPosition);
        entry.SetRow(prefix + orbital.name, orbital.OrbitalDistance);
        go.SetActive(true);

        currentRows.Add(go);
    }

    private void SetTableContentHeight()
    {
        float ySize = (currentRows.Count + 1) * rowHeight;
        bool smallerThanViewport = ySize < viewportHeight;

        if (smallerThanViewport) return;

        content.sizeDelta = new Vector2(content.sizeDelta.x, ySize);
    }

    private void Start()
    {
        rowHeight = tableEntryTemplate.GetComponent<RectTransform>().rect.height;
        currentPositionY = tableHeader.anchoredPosition.y - rowHeight;
        viewportHeight = viewport.rect.height;
    }

}

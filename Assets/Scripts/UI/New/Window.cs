using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private List<Panel> panelPrefabs;

    protected Dictionary<string, Panel> panels;

    private void Awake()
    {
        panels = new Dictionary<string, Panel>();
    }

    private void Start()
    {
        foreach(Panel panel in panelPrefabs)
        {
            AddPanel(panel.id, panel);
        }
    }

    public void AddPanel(string key, Panel newPanel) {
        panels.Add(key, newPanel);
    }

    public void OpenPanel(string panelId) => SetPanelActive(panelId, true);

    public void ClosePanel(string panelId) => SetPanelActive(panelId, false);

    private void SetPanelActive(string panelId, bool active)
    {
        if (panels.TryGetValue(panelId, out Panel panel)) {
            panel.SetActive(active);
            return;
        }
        throw new KeyNotFoundException();
    }

    public void RefreshAll()
    {
        foreach(KeyValuePair<string, Panel> entry in panels)
        {
            entry.Value.Refresh();
        }
    }

    public void RefreshPanel(string panelId, object payload = null)
    {
        if (panels.TryGetValue(panelId, out Panel panel))
        {
            panel.Refresh(payload);
        }
    }
}

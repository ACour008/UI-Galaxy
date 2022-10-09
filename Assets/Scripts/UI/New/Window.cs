using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window
{
    private Dictionary<string, Panel> panels;

    public Window()
    {
        panels = new Dictionary<string, Panel>();
    }

    public void AddPanel(string key, Panel newPanel) {
        panels.Add(key, newPanel);
    }

    public void OpenPanel(string panelId) => SetPanelActive(panelId, true);

    public void ClosePanel(string panelId) => SetPanelActive(panelId, false);

    private void SetPanelActive(string panelId, bool active)
    {
        if (panels.TryGetValue(panelId, out Panel panel)) {
            panel.Activate();
            return;
        }
        throw new KeyNotFoundException();
    }

    public void Refresh()
    {
        foreach(KeyValuePair<string, Panel> entry in panels)
        {
            entry.Value.Refresh();
        }
    }
}

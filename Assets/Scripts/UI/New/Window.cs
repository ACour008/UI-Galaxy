using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window: MonoBehaviour
{
    private Dictionary<int, Panel> panels;
    private static int PanelId = 0;

    public Window()
    {
        panels = new Dictionary<int, Panel>();
    }

    public void AddPanel(Panel newPanel) {
        panels.Add(++PanelId, newPanel);
    }

    public void OpenPanel(int id) => SetPanelActive(id, true);

    public void ClosePanel(int id) => SetPanelActive(id, false);

    private void SetPanelActive(int id, bool active)
    {
        if (panels.TryGetValue(id, out Panel p)) {
            p.gameObject.SetActive(active);
            return;
        }
        throw new KeyNotFoundException();
    }
}

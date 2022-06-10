using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour, IClickable
{
    [SerializeField] private StarInfoPanel infoPanel;
    [SerializeField] private Selector selector;
    public void OnPointerClicked()
    {
        infoPanel.ClearAll();
        selector.ClearSelected();

        if (Galaxy.StarSystemsDebug != null)
        {
            foreach(StarSystem s in Galaxy.StarSystemsDebug)
            {
                
                s.ChangeColor(s.Color);
            }
        }
    }
}

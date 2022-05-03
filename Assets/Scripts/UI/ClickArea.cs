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

        if (Galaxy.Stars != null)
        {
            foreach(Star s in Galaxy.Stars)
            {
                SpriteRenderer sr = s.transform.GetChild(0).GetComponent<SpriteRenderer>();
                sr.color = s.Color;
            }
        }
    }
}

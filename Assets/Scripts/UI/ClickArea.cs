using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArea : MonoBehaviour, IClickable
{
    [SerializeField] private StarInfoPanel infoPanel;
    [SerializeField] private UISelector selector;
    public void OnPointerClicked()
    {
        infoPanel?.ClearAll();
        selector?.ClearSelected();
    }
}

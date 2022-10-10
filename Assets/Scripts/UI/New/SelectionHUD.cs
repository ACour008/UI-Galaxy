using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHUD : Window
{
    private bool isOpen = false;
    StarSystem star;

    public void Open(StarSystem star) {
        this.star = star;
        OpenPanel("selection");
        isOpen = true;
    }

    public void Close()
    {
        ClosePanel("selection");
        isOpen = false;
    }

    private void Update() {
        if (isOpen) {
            RefreshPanel("selection", star);
        }
    }
}

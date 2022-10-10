using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHUD : Window
{
    public void Open(StarSystem star)
    {
        OpenPanel("star-properties");
        RefreshPanel("star-properties", star);
    }

    public void Close()
    {
        ClosePanel("star-properties");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICamInitializer
{
    public void InitializeCamera(Camera mainCam, EventSystem eventSystem);
}

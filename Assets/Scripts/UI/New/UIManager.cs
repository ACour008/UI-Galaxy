using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Window mainHUD;
    
    public StarSystem selectedSystem;

    private void Awake() {
        instance = this;
    }

    public void OnStarClicked(StarSystem star) 
    {
        selectedSystem = star;
        mainHUD.OpenPanel("star-properties");
    }
}

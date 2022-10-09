using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorFactory: MonoBehaviour
{
    // [SerializeField] private StarInfoPanel infoPanel; // for now; this needs to go into a new class UIHandler maybe...?
    // [SerializeField] private UISelector selector;

    static StarCreator starCreator;
    static PlanetCreator planetCreator;
    static JumpGateCreator jumpGateCreator;
    static StarSystemCreator systemCreator;
    static MoonCreator moonCreator;
    static SpaceStationCreator spacePortCreator;

    static DataManager dataManager;
    // public static UISelector Selector;

    public void Awake()
    {
        dataManager = new DataManager();
        // CreatorFactory.Selector = this.selector;
    }

    public static Creator<T2> GetCreatorFor<T2>()
    {

        Type typeofT2 = typeof(T2);

        if (typeofT2 == typeof(Star))
        {
            if (starCreator == null) starCreator = new StarCreator(dataManager);
            return starCreator as Creator<T2>;
        }
        else if (typeofT2 == typeof(Planet))
        {
            if (planetCreator == null) planetCreator = new PlanetCreator(dataManager);
            return planetCreator as Creator<T2>;
        }
        else if (typeofT2 == typeof(JumpGate))
        {
            if (jumpGateCreator == null) jumpGateCreator = new JumpGateCreator(dataManager);
            return jumpGateCreator as Creator<T2>;
        }
        else if (typeofT2 == typeof(StarSystem))
        {
            if (systemCreator == null) systemCreator = new StarSystemCreator(dataManager);
            return systemCreator as Creator<T2>;
        }
        else if (typeofT2 == typeof(Moon))
        {
            if (moonCreator == null) moonCreator = new MoonCreator(dataManager);
            return moonCreator as Creator<T2>;
        }
        else if (typeofT2 == typeof(SpaceStation))
        {
            if (spacePortCreator == null) spacePortCreator = new SpaceStationCreator(dataManager);
            return spacePortCreator as Creator<T2>;
        }

        return null;
    }

}


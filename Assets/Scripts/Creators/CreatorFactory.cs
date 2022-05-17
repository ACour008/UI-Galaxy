using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorFactory:MonoBehaviour
{
    static StarCreator starCreator;
    static PlanetCreator planetCreator;
    static JumpGateCreator jumpGateCreator;
    static StarSystemCreator systemCreator;
    static MoonCreator moonCreator;
    static SpaceStationCreator spacePortCreator;

    static DataManager dataManager;

    public void Awake()
    {
        dataManager = new DataManager();
    }

    public static Creator GetCreatorFor<T2>()
    {

        Type typeofT2 = typeof(T2);

        if (typeofT2 == typeof(Star))
        {
            if (starCreator == null) starCreator = new StarCreator(dataManager);
            return starCreator as StarCreator;
        }
        else if (typeofT2 == typeof(Planet))
        {
            if (planetCreator == null) planetCreator = new PlanetCreator(dataManager);
            return planetCreator as PlanetCreator;
        }
        else if (typeofT2 == typeof(JumpGate))
        {
            if (jumpGateCreator == null) jumpGateCreator = new JumpGateCreator(dataManager);
            return jumpGateCreator as JumpGateCreator;
        }
        else if (typeofT2 == typeof(StarSystem))
        {
            if (systemCreator == null) systemCreator = new StarSystemCreator(dataManager);
            return systemCreator as StarSystemCreator;
        }
        else if (typeofT2 == typeof(Moon))
        {
            if (moonCreator == null) moonCreator = new MoonCreator(dataManager);
            return moonCreator as MoonCreator;
        }
        else if (typeofT2 == typeof(SpaceStation))
        {
            if (spacePortCreator == null) spacePortCreator = new SpaceStationCreator(dataManager);
            return spacePortCreator as SpaceStationCreator;
        }

        return null;
    }

}


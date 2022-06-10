using System;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : Orbital
{
    [SerializeField] private bool showGizmos;
    [SerializeField] private bool discoveryMode;
    [SerializeField] private int seed;

    [SerializeField] private StarInfoPanel infoPanel; // for now; this needs to go into a new class UIHandler maybe...?
    [SerializeField] private Selector selector;

    private int sectorSizeX;
    private int sectorSizeY;
    private GalaxyHash galaxyHash;

    private bool initialized = false;

    // for debug.
    public static List<StarSystem> StarSystemsDebug;
    private StarSystemCreator systemCreator;

    public Transform Transform { get => this.transform; }
    public bool InitializationComplete { get => initialized; }
    public GalaxyHash StarSystems { get => galaxyHash; }

    public override double Radius { get => 0; }
    public override double Mass { get => 0; }

    private void Awake()
    {
        LehmerRNG.Initialize(seed);
    }

    public override void Initialize(OrbitalSettings setting, Orbital parent, bool generateAll)
    {
        sectorSizeX = Mathf.RoundToInt(Screen.width / 8);
        sectorSizeY = Mathf.RoundToInt(Screen.height / 8);

        galaxyHash = new GalaxyHash(sectorSizeX, sectorSizeY, 16);

        systemCreator.CreateOrbitals(parent, galaxyHash, generateAll);

        initialized = true;
    }

    private void Star_OnClicked(object sender, OnStarSystemClickEventArgs eventArgs)
    {
        StarSystem system = eventArgs.system;
        Galaxy.StarSystemsDebug = galaxyHash.GetCellAt(system.Position);

        foreach (StarSystem s in Galaxy.StarSystemsDebug)
        {
            s.ChangeColor(Color.green);
        }
    }

    private void Start()
    {
        systemCreator = CreatorFactory.GetCreatorFor<StarSystem>() as StarSystemCreator;
        Initialize(new GalaxySettings(), this, discoveryMode);
    }

    #region Debug

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            int sectorSizeX = 240;
            int sectorSizeY = 135;

            Gizmos.color = Color.yellow;
            int maxSize = Mathf.Max(sectorSizeX, sectorSizeY);

            for (int i = 0; i <= sectorSizeX; i += 8)
            {
                Gizmos.DrawLine(new Vector3(i, 0), new Vector3(i, sectorSizeY));
            }

            for (int j = 0; j <= sectorSizeY; j += 8)
            {
                Gizmos.DrawLine(new Vector3(0, j), new Vector3(sectorSizeX, j));
            }
        }
    }
    #endregion
}

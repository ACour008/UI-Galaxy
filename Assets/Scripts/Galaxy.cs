using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : OrbitalBase, IOrbital
{
    [SerializeField] private bool showGizmos;
    [SerializeField] private bool discoveryMode;
    [SerializeField] private int seed;
    [SerializeField] private float zoomFactor;

    [SerializeField] private StarInfoPanel infoPanel; // for now; this needs to go into a new class UIHandler maybe...?
    [SerializeField] private Selector selector;

    private int sectorSizeX;
    private int sectorSizeY;

    private GalaxyHash galaxyHash;

    // for debug.
    public static List<StarSystem> StarSystems;

    private StarSystemCreator systemCreator;

    public Transform Transform { get => this.transform; }

    private void Awake()
    {
        LehmerRNG.Initialize(seed);
    }

    public void HandleConnection(StarSystem system, StarSystem other, bool ignoreLimit = false)
    {
        system.AddJumpGateTo(other, ignoreLimit);

        system.AddToAdjacency(other);
        other.AddToAdjacency(system);
    }

    private void CreateJumpgateFor(StarSystem starSystem, List<StarSystem> cell)
    {
        if (cell.Count <= 1) return;
        cell.Sort((ss1, ss2) => Mathf.FloorToInt(Vector3.Distance(ss1.Position, starSystem.Position)).CompareTo(Mathf.FloorToInt(Vector3.Distance(ss2.Position, starSystem.Position))));

        int searchIdx = 1;
        StarSystem otherSystem = cell[searchIdx];
        float maxDistance = 16f;
        bool connected = false;

        while (!connected && searchIdx < cell.Count - 1)
        {
            bool systemsHaveSpaceToConnect = starSystem.HasOpenSpacesForJumpgates() && otherSystem.HasOpenSpacesForJumpgates();
            bool areWithinRange = Vector3.Distance(starSystem.Position, otherSystem.Position) < maxDistance;
            bool areConnected = starSystem.HasConnectionTo(otherSystem.Id) || otherSystem.HasConnectionTo(starSystem.Id);

            if (systemsHaveSpaceToConnect && areWithinRange && !areConnected)
            {
                HandleConnection(starSystem, otherSystem);
                connected = true;
            }
            else
            {
                searchIdx++;
                otherSystem = cell[searchIdx];
            }
        }

        (int x, int y) coordinates = galaxyHash.GetCellCoordinates(starSystem.Position);
        List<StarSystem> neighborCell;

        if (starSystem.Position.x < coordinates.x - 4)
        {
            neighborCell = galaxyHash.GetCellAtCoordinate(coordinates.x - 16, coordinates.y);
            if (neighborCell == null) return;

            neighborCell.Sort((ss1, ss2) => Mathf.FloorToInt(Vector3.Distance(ss1.Position, starSystem.Position)).CompareTo(Mathf.FloorToInt(Vector3.Distance(ss2.Position, starSystem.Position))));
            HandleConnection(starSystem, neighborCell[0], true);
        }

        if (starSystem.Position.x > coordinates.x + 4)
        {
            neighborCell = galaxyHash.GetCellAtCoordinate(coordinates.x + 16, coordinates.y);
            if (neighborCell == null) return;

            neighborCell.Sort((ss1, ss2) => Mathf.FloorToInt(Vector3.Distance(ss1.Position, starSystem.Position)).CompareTo(Mathf.FloorToInt(Vector3.Distance(ss2.Position, starSystem.Position))));
            HandleConnection(starSystem, neighborCell[0], true);
        }

        if (starSystem.Position.y < coordinates.y - 4)
        {
            neighborCell = galaxyHash.GetCellAtCoordinate(coordinates.x, coordinates.y - 16);
            if (neighborCell == null) return;
            neighborCell.Sort((ss1, ss2) => Mathf.FloorToInt(Vector3.Distance(ss1.Position, starSystem.Position)).CompareTo(Mathf.FloorToInt(Vector3.Distance(ss2.Position, starSystem.Position))));
            HandleConnection(starSystem, neighborCell[0], true);
        }

        if (starSystem.Position.y > coordinates.y + 4)
        {
            neighborCell = galaxyHash.GetCellAtCoordinate(coordinates.x, coordinates.y + 16);
            if (neighborCell == null) return;
            neighborCell.Sort((ss1, ss2) => Mathf.FloorToInt(Vector3.Distance(ss1.Position, starSystem.Position)).CompareTo(Mathf.FloorToInt(Vector3.Distance(ss2.Position, starSystem.Position))));
            HandleConnection(starSystem, neighborCell[0], true);
        }
    }

    public void CreateOrbitals(OrbitalSettings setting, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        for (int i = 0; i < sectorSizeX * sectorSizeY; i++)
        {
            float radius = Mathf.Min(sectorSizeY, sectorSizeX);
            float xRadius = LehmerRNG.NextFloat(0, radius);
            float yRadius = LehmerRNG.NextFloat(0, radius);
            float angle = LehmerRNG.NextFloat(0, Mathf.PI * 2);

            // int xPosition = (int)((i / sectorSizeX) + Mathf.Cos(angle) * radius);
            // int yPosition = (int)((i % sectorSizeY) + Mathf.Sin(angle) * radius);

            int xPosition = (int)(sectorSizeX + Mathf.Cos(angle) * xRadius);
            int yPosition = (int)(sectorSizeY + Mathf.Sin(angle) * yRadius);

            StarSystem starSystem = systemCreator.Create(i, xPosition, yPosition, this, !discoveryMode);

            if (starSystem != null)
            {
                /*                starSystem.OnClicked += infoPanel.Star_OnClicked;
                       starSystem.OnClicked += selector.Star_OnClicked;*/
                starSystem.OnClicked += Star_OnClicked;
                
                galaxyHash.Add(starSystem);
                CreateJumpgateFor(starSystem, galaxyHash.GetCellAt(starSystem.Position));
            }
        }
    }

    public void Initialize(int id, OrbitalSettings setting, IOrbital parent, Dictionary<int, int> childrenProbabilities, bool generateAll)
    {
        sectorSizeX = Mathf.RoundToInt(Screen.width / 8);
        sectorSizeY = Mathf.RoundToInt(Screen.height / 8);

        galaxyHash = new GalaxyHash(sectorSizeX, sectorSizeY, 16);

        CreateOrbitals(setting, this, null, generateAll);
    }

    private void Star_OnClicked(object sender, OnStarSystemClickEventArgs eventArgs)
    {
        StarSystem system = eventArgs.system;
        Galaxy.StarSystems = galaxyHash.GetCellAt(system.Position);

        foreach (StarSystem s in Galaxy.StarSystems)
        {
            s.ChangeColor(Color.green);
        }

    }

    private void Start()
    {
        systemCreator = (StarSystemCreator)CreatorFactory.GetCreatorFor<StarSystem>();

        Initialize(0, new GalaxySettings(), this, null, !discoveryMode);
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

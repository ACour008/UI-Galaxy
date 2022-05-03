using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    [SerializeField] private bool showGizmos;
    [SerializeField] private bool discoveryMode;
    [SerializeField] private int seed;
    [SerializeField] private float zoomFactor;

    [SerializeField] private StarInfoPanel infoPanel; // for now; this needs to go into a new class UIHandler maybe...?
    [SerializeField] private Selector selector;

    public static List<Star> Stars;

    private GalaxyHash galaxyHash;
    private StarCreator starCreator;

    private void Awake()
    {
        LehmerRNG.Initialize(seed);
    }

    private void Start()
    {
        starCreator = (StarCreator)CreatorFactory.GetCreatorFor<Star>();
        Initialize();
    }

    private void Initialize()
    {
        int sectorSizeX = Mathf.RoundToInt(Screen.width / 8);
        int sectorSizeY = Mathf.RoundToInt(Screen.height / 8);

        Debug.Log(sectorSizeX);
        Debug.Log(sectorSizeY);

        galaxyHash = new GalaxyHash(sectorSizeX, sectorSizeY, 8);

        for (int i = 0; i < sectorSizeX * sectorSizeY; i++)
        {
            int xPosition = i / sectorSizeX;
            int yPosition = i % sectorSizeY;

            Star star = starCreator.Create(xPosition, yPosition, zoomFactor, this.transform, !discoveryMode);

            if (star != null)
            {
                star.OnClicked += infoPanel.Star_OnClicked;
                star.OnClicked += selector.Star_OnClicked;
                star.OnClicked += Star_OnClicked;
                galaxyHash.Add(star);
            }
        }
    }

    private void Star_OnClicked(object sender, OnStarClickEventArgs eventArgs)
    {
        Star star = eventArgs.star;
        Galaxy.Stars = galaxyHash.GetSharedBucketAs(star);

        foreach(Star s in Galaxy.Stars)
        {
            SpriteRenderer sr = s.transform.GetChild(0).GetComponent<SpriteRenderer>();
            sr.color = Color.green;
        }

    }

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy:MonoBehaviour
{
    [SerializeField] private bool showGizmos;
    [SerializeField] private bool discoveryMode;
    [SerializeField] private int seed;

    [SerializeField] private StarInfoPanel infoPanel; // for now; this needs to go into a new class UIHandler maybe...?
    [SerializeField] private Selector selector;

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
        int sectorSizeX = Mathf.FloorToInt(Screen.width / 8);
        int sectorSizeY = Mathf.FloorToInt(Screen.height / 8);

        // Debug.Log($"Sector Size: {sectorSizeX}, {sectorSizeY}");

        for (int xPosition = 0; xPosition < sectorSizeX; xPosition++)
        {
            for (int yPosition = 0; yPosition < sectorSizeY; yPosition++)
            {
                Star star = starCreator.Create(xPosition, yPosition, this.transform, !discoveryMode);

                if (star != null)
                {
                    star.OnClicked += infoPanel.Star_OnClicked;
                    star.OnClicked += selector.Star_OnClicked;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            int sectorSizeX = 240;
            int sectorSizeY = 135;

            Gizmos.color = Color.yellow;
            int maxSize = (int)Mathf.Max(sectorSizeX, sectorSizeY);

            for (float i = 0f; i <maxSize; i += 16f)
            {
                if (i < sectorSizeX) Gizmos.DrawLine(new Vector3(i, 0), new Vector3(i, sectorSizeY));
                if (i < sectorSizeY) Gizmos.DrawLine(new Vector3(0, i), new Vector3(sectorSizeX, i));

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy:MonoBehaviour
{
    [SerializeField] private bool showGizmos;
    [SerializeField] private bool discoveryMode;
    [SerializeField] private int seed;

    [SerializeField] private StarInfoPanel infoPanel; // for now;
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

            for (float x = 0f; x < sectorSizeX; x += 16)
            {
                Gizmos.DrawLine(new Vector3(x, 0), new Vector3(x, sectorSizeY));
                
            }

            for (float y = 0f; y < sectorSizeY; y += 16)
            {
                Gizmos.DrawLine(new Vector3(0, y), new Vector3(sectorSizeX, y));
            }
        }
    }
}

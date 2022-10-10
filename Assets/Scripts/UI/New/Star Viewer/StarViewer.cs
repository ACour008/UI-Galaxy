using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarViewer : MonoBehaviour
{
    [SerializeField] MiniMapCameraController viewerCam;

    List<Star> currentStars;

    void Start()
    {
        currentStars = new List<Star>();
    }

    public void ShowSystem(StarSystem starSystem)
    {
        float largestScale = -1000;
        foreach(Star star in starSystem.Stars)
        {
            float xPosition = (float)(star.OrbitalDistance * Mathf.Cos(star.Angle) / 1e9);
            float yPosition = (float)(star.OrbitalDistance * Mathf.Sin(star.Angle) / 1e9);

            float scale = (float)(star.Radius / Utils.Conversions.RO_SUN) * 2f;
            if (scale > largestScale) largestScale = scale;
            
            star.transform.localPosition = new Vector3(xPosition, yPosition, 0);
            star.transform.localScale = new Vector3(scale, scale, 1);

            star.transform.SetParent(transform, false);
            star.gameObject.SetActive(true);
            currentStars.Add(star);
        }

        viewerCam.FitScreen(largestScale);
    }

    public void Clear(StarSystem starSystem)
    {
        for (int i = currentStars.Count - 1; i >= 0; i--)
        {
            Star star = currentStars[i];
            star.transform.SetParent(starSystem.transform, false);
            star.transform.SetSiblingIndex(star.ID);
            star.gameObject.SetActive(false);

            star.transform.localPosition = new Vector3(0, 0, 0);
            star.transform.localScale = new Vector3(1, 1, 1);

            currentStars.RemoveAt(i);
        }
    }
}

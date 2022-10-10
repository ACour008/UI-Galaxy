using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniMapCameraController : MonoBehaviour
{
    // Increase ortho, zoom out; Decrease ortho, zoom in;
    [Header("Orthographic Sizes")]
    [SerializeField] float smallStarOrthoSize = 5;
    [SerializeField] float defaultOrthoSize = 7;
    [SerializeField] float largeStarOrthoSize = 20;
    [SerializeField] float xlLargeStarOrthoSize = 60;


    [SerializeField] float zoomSpeed;

    private Camera cam;
    private float zoomStartTime;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void FitScreen(float scale)
    {
        float targetOrthoSize;

        if (scale < 0.5f)     targetOrthoSize = smallStarOrthoSize;    
        else if (scale < 7f)  targetOrthoSize = defaultOrthoSize;
        else if (scale < 20f) targetOrthoSize = largeStarOrthoSize;
        else targetOrthoSize = xlLargeStarOrthoSize;

        if (cam.orthographicSize == targetOrthoSize) return;

        StopAllCoroutines();
        zoomStartTime = Time.time;
        StartCoroutine(ZoomTo(targetOrthoSize));
    }

    // What if we make this one method that takes:
    // a) a condition for the while to test
    // b) the target orthoSize
    private IEnumerator ZoomTo(float targetOrthoSize)
    {
        while (cam.orthographicSize != targetOrthoSize)
        {
            Debug.Log($"Lerping: {cam.orthographicSize}");
            float completed = (Time.time - zoomStartTime) * zoomSpeed;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetOrthoSize, Mathf.SmoothStep(0, 1, completed));
            yield return null;
        }
        cam.orthographicSize = targetOrthoSize;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Panning")]
    [SerializeField] Vector2 minPosition;
    [SerializeField] Vector2 maxPosition;
    [SerializeField] float speed = 3f;
    [SerializeField] float zPosition = -10f;

    [Header("Zoom")]
    [SerializeField] float startZoomLevel = 5f;
    [SerializeField] MinMax<float> zoomLevels;
    [SerializeField] float zoomRate = 5f;

    private Camera mainCam;

    private void Start()
    {
        mainCam = GetComponent<Camera>();
    }


    public void Move(Vector2 deltaPosition)
    {

        Vector3 moveTo = new Vector3(deltaPosition.x, deltaPosition.y, 0);
        Vector3 target = transform.position - moveTo * Time.deltaTime * speed;

        float clampedX = Mathf.Clamp(target.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(target.y, minPosition.y, maxPosition.y);

        transform.position = new Vector3(clampedX, clampedY, zPosition);

    }

    private void SetZoomLevel(float zoomRate)
    {

        mainCam.orthographicSize = zoomRate;
    }

    public void Zoom(float zoomRate)
    {
        Debug.Log(zoomRate);

        float rate = 1 + zoomRate * Time.unscaledDeltaTime;
        float target = Mathf.MoveTowards(mainCam.orthographicSize, mainCam.orthographicSize / rate, 0.1f);
        SetZoomLevel(Mathf.Clamp(target, zoomLevels.min, zoomLevels.max));
    }

    public void OnZoomInButtonClicked(float zoomRate)
    {
        Zoom(zoomRate);
    }

    public void OnZoomOutButtonClicked(float zoomRate)
    {

        float rate = 1 + zoomRate * Time.unscaledDeltaTime;
        float target = Mathf.MoveTowards(mainCam.orthographicSize, mainCam.orthographicSize * rate, 0.1f);
        SetZoomLevel(Mathf.Clamp(target, zoomLevels.min, zoomLevels.max));
    }
}

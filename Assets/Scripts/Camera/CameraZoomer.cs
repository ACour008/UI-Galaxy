using UnityEngine;
using UnityEngine.EventSystems;

public class CameraZoomer : MonoBehaviour, IZoomHandler
{
    [SerializeField] float zoomScaleFactor = 1.1f;
    [SerializeField] float startZoomLevel = 5f;
    [SerializeField] MinMax<float> zoomLevels;

    private Camera mainCam;
    private float zPosition;
    private EventSystem eventSystem;

    public void InitializeCamera(Camera mainCam, EventSystem eventSystem)
    {
        this.mainCam = mainCam;
        this.eventSystem = eventSystem;
        zPosition = this.mainCam.transform.position.z;
    }

    public void OnZoomClick(float direction)
    {
        eventSystem.SetSelectedGameObject(null);
        Zoom(direction, new Vector2(0, 0));
    }

    public void SetZoomLevel(float zoomRate)
    {
        mainCam.orthographicSize = zoomRate;
    }

    private void Start()
    {
        mainCam.orthographicSize = startZoomLevel;
    }

    public void Zoom(float direction, Vector2 mousePosition)
    {
        if (direction == 0) return;

        if (direction < 0)
        {
            if (mainCam.orthographicSize < zoomLevels.max)
            {
                ZoomOutBy(zoomScaleFactor, mousePosition);
            }
        }
        else
        {
            if (mainCam.orthographicSize > zoomLevels.min)
            {
                ZoomInBy(zoomScaleFactor, mousePosition);
            }
        }
    }

    public void ZoomInBy(float scaleFactor, Vector2 mousePosition)
    {
        if (scaleFactor < 0) return;
        if (scaleFactor < 1) scaleFactor += 1f;

        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);

        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 length = mousePosition - position;
        Vector2 scaledLength = length / scaleFactor;
        Vector2 deltaLength = length - scaledLength;

        // PrintZoomDetails(position, mousePosition, length, scaledLength, deltaLength);

        transform.position = new Vector3(position.x + deltaLength.x, position.y + deltaLength.y, zPosition);
        SetZoomLevel(Mathf.Clamp(mainCam.orthographicSize / scaleFactor, zoomLevels.min, zoomLevels.max));
    }

    public void ZoomOutBy(float scaleFactor, Vector2 mousePosition)
    {
        if (scaleFactor < 0) return;
        if (scaleFactor < 1) scaleFactor += 1f;

        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);

        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 length = mousePosition - position;
        Vector2 scaledLength = length * scaleFactor;
        Vector2 deltaLength = length - scaledLength;

        // PrintZoomDetails(position, mousePosition, length, scaledLength, deltaLength);

        transform.position = new Vector3(position.x + deltaLength.x, position.y + deltaLength.y, zPosition);
        SetZoomLevel(Mathf.Clamp(mainCam.orthographicSize * scaleFactor, zoomLevels.min, zoomLevels.max));
    }
}

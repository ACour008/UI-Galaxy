using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [Header("Panning")]
    [SerializeField] MinMax<Vector2> panPositions;
    [SerializeField] float zPosition = -10f;

    Vector2 dragOrigin = Vector2.zero;
    Vector3 dragVelocity = Vector3.zero;

    [Header("Zoom")]
    [SerializeField] float zoomScaleFactor = 1.1f;
    [SerializeField] float startZoomLevel = 5f;
    [SerializeField] MinMax<float> zoomLevels;

    private Camera mainCam;
    private EventSystem eventSystem;

    public void ClearDragData()
    {
        dragOrigin = Vector2.zero;
        dragVelocity = Vector3.zero;
    }

    public void Move(Vector2 mousePosition)
    {
        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);

        Vector2 deltaPosition = dragOrigin - mousePosition;
        Vector3.SmoothDamp(deltaPosition, mousePosition, ref dragVelocity, 0.1f, 250f, Time.deltaTime);

        transform.position += new Vector3(deltaPosition.x, deltaPosition.y, 0) * dragVelocity.magnitude * Time.deltaTime;
        
        float clampedX = Mathf.Clamp(transform.position.x, panPositions.min.x, panPositions.max.x);
        float clampedY = Mathf.Clamp(transform.position.y, panPositions.min.y, panPositions.max.y);
        transform.position = new Vector3(clampedX, clampedY, -10);
    }

    public void SetDragOrigin(Vector2 mousePosition)
    {
        dragOrigin = mainCam.ScreenToWorldPoint(mousePosition);
    }

    private void SetZoomLevel(float zoomRate)
    {
        mainCam.orthographicSize = zoomRate;
    }

    private void Start()
    {
        mainCam = GetComponent<Camera>();
        eventSystem = EventSystem.current;
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

    public void ZoomClick(float direction)
    {
        eventSystem.SetSelectedGameObject(null);
        Zoom(direction, new Vector2(0, 0));
    }

    private void ZoomInBy(float scaleFactor, Vector2 mousePosition)
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

    private void ZoomOutBy(float scaleFactor, Vector2 mousePosition)
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

    #region Debug
    private void PrintZoomDetails(Vector2 position, Vector2 mousePosition, Vector2 length, Vector2 scaledLength, Vector2 deltaLength)
    {
        Debug.Log($"P: {position}");
        Debug.Log($"MP: {mousePosition}");
        Debug.Log($"Length check: {mousePosition - position}, {length}");
        Debug.Log($"SL: {scaledLength}");
        Debug.Log($"DL: {deltaLength}");
        Debug.Log($"DP: {position + deltaLength}");
    }
    #endregion
}

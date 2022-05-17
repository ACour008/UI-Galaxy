using UnityEngine;
using UnityEngine.EventSystems;

public class CameraPanner : MonoBehaviour, IPanHandler
{
    [SerializeField] MinMax<Vector2> panPositions;

    Camera mainCam;
    float zPosition;
    Vector2 dragOrigin = Vector2.zero;
    Vector3 dragVelocity = Vector3.zero;
    EventSystem eventSystem;

    public void ClearDragData()
    {
        dragOrigin = Vector2.zero;
        dragVelocity = Vector3.zero;
    }

    public void InitializeCamera(Camera mainCam, EventSystem eventSystem)
    {
        this.mainCam = mainCam;
        this.eventSystem = eventSystem;
        zPosition = this.mainCam.transform.position.z;
    }

    public void Pan(Vector2 mousePosition)
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
}

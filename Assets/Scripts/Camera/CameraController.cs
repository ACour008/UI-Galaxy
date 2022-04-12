using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 minPosition;
    [SerializeField] Vector2 maxPosition;

    public void Move(Vector2 origin, Vector2 target)
    {
        Vector3 viewportOrigin = Camera.main.ScreenToViewportPoint(origin);
        Vector3 viewportTarget = Camera.main.ScreenToViewportPoint(target);

        float xPosition = (viewportOrigin.x - viewportTarget.x) * Time.deltaTime * moveSpeed;
        float yPosition = (viewportOrigin.y - viewportTarget.y) * Time.deltaTime * moveSpeed;

        float clampedX = Mathf.Clamp(transform.position.x + xPosition, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(transform.position.y + yPosition, minPosition.y, maxPosition.y);

        transform.position = new Vector3(clampedX, clampedY, -10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector2 minPosition;
    [SerializeField] Vector2 maxPosition;
    [SerializeField] float speed = 3;
    [SerializeField] float zPosition = -10f;


    public void Move(Vector2 absoluteDelta)
    {
        Vector3 moveTo = new Vector3(absoluteDelta.x, absoluteDelta.y, 0) * speed;
        Vector3 target = transform.position - moveTo;

        float clampedX = Mathf.Clamp(target.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(target.y, minPosition.y, maxPosition.y);

        transform.position = new Vector3(clampedX, clampedY, zPosition);

    }
}

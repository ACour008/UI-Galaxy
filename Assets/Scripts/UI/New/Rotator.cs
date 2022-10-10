using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] bool rotateClockwise;
    [SerializeField] float speed;

    private float direction;

    void Start()
    {
        direction = (rotateClockwise) ? -1 : 1;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * direction));        
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraPanner panner;
    [SerializeField] private CameraZoomer zoomer;
    [SerializeField] private InputController input;
    private bool startDrag = false;

    public CameraPanner Panner { get => panner; }
    public CameraZoomer Zoomer { get => zoomer; }
    public bool StartDrag { get => startDrag; set => startDrag = value; }

    private void Init(Camera camera, InputController input, EventSystem eventSystem)
    {
        this.input = input;

        panner?.InitializeCamera(camera, eventSystem);
        zoomer?.InitializeCamera(camera, eventSystem);
    }

    private void LateUpdate()
    {
        if (startDrag) panner?.Pan(Mouse.current.position.ReadValue());
    }

    private void Start()
    {
        Init(GetComponent<Camera>(), input, EventSystem.current);
    }
}

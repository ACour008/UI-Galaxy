using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputControls inputControls;
    private InputRaycaster2D raycaster;

    [Header("Camera Movement")]
    [SerializeField] CameraController cameraController;
    private InputAction.CallbackContext context;


    [Header("Raycast Info")]
    [SerializeField] LayerMask hitLayers;
    [SerializeField] string clickableTag;

    void Awake()
    {
        inputControls = new InputControls();
        raycaster = new InputRaycaster2D(inputControls, clickableTag);

    }

    private void OnDisable() => inputControls?.Disable();

    private void OnEnable() => inputControls?.Enable();

    private void OnLeftButtonClicked(InputAction.CallbackContext context)
    {
        raycaster.PerformCheck(hitLayers);
        if (raycaster.HitTarget != null)
        {
            IClickable clickable = raycaster.HitTarget.GetComponent<IClickable>();
            if (clickable != null) clickable.OnPointerClicked();
        }
    }

    public void OnMiddleButtonClicked(InputAction.CallbackContext ctx)
    {
        context = ctx;
    }

    private void OnWheelScrolled(InputAction.CallbackContext ctx)
    {
        float zoomLevel = ctx.ReadValue<Vector2>().y;
        Vector2 mousePosition = inputControls.Mouse.Position.ReadValue<Vector2>();
        cameraController.Zoom(zoomLevel, mousePosition);
    }

    private void Start()
    {
        inputControls.Mouse.LeftButton.performed += OnLeftButtonClicked;
        inputControls.Mouse.MiddleButton.started += OnMiddleButtonClicked;
        inputControls.Mouse.ScrollWheel.performed += OnWheelScrolled;
    }

    private void Update()
    {
        bool mouseIsDown = context.performed;
        if (mouseIsDown)
        {
            Vector2 mousePositionDelta = inputControls.Mouse.DeltaPosition.ReadValue<Vector2>();
            cameraController.Move(mousePositionDelta);
        }
    }
}

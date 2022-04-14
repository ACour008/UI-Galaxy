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
    private Vector2 prevPos;


    [Header("Raycast Info")]
    [SerializeField] LayerMask hitLayers;
    [SerializeField] string clickableTag;

    void Awake()
    {
        inputControls = new InputControls();
        raycaster = new InputRaycaster2D(inputControls, clickableTag);

    }

    private void LateUpdate()
    {
        bool mouseIsDown = context.performed;
        if (mouseIsDown)
        {
            Vector2 deltaPosition = inputControls.Mouse.DeltaPosition.ReadValue<Vector2>();
            cameraController.Move(deltaPosition);
        }
    }

    private void OnLeftButtonClicked(InputAction.CallbackContext context)
    {
        raycaster.PerformCheck(hitLayers);
        if (raycaster.HitTarget != null)
        {
            IClickable clickable = raycaster.HitTarget.GetComponent<IClickable>();
            if (clickable != null) clickable.OnPointerClicked();
        }
    }

    private void OnDisable() => inputControls?.Disable();

    private void OnEnable() => inputControls?.Enable();


    private void Start()
    {
        inputControls.Mouse.LeftButton.performed += OnLeftButtonClicked;
        inputControls.Mouse.MiddleButton.started += MiddleButton_started;

    }

    public void MiddleButton_started(InputAction.CallbackContext ctx)
    {
        context = ctx;
    }
}

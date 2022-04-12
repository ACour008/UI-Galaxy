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
    private bool shouldUpdateCamera = false;
    private Vector2 mouseOriginPosition;
    private Vector2 mouseTargetPosition;
    private Vector2 previousMosueDirection;


    [Header("Raycast Info")]
    [SerializeField] LayerMask hitLayers;
    [SerializeField] string clickableTag;

    void Awake()
    {
        inputControls = new InputControls();
        raycaster = new InputRaycaster2D(inputControls, clickableTag);

    }
    private void MiddleButton_canceled(InputAction.CallbackContext obj)
    {
        shouldUpdateCamera = false;
        
    }

    private void MiddleButton_performed(InputAction.CallbackContext obj)
    {
        mouseOriginPosition = inputControls.Mouse.Position.ReadValue<Vector2>();
        shouldUpdateCamera = true;
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
        inputControls.Mouse.MiddleButton.performed += MiddleButton_performed;
        inputControls.Mouse.MiddleButton.canceled += MiddleButton_canceled;

    }

    private void Update()
    {
        if (shouldUpdateCamera)
        {
            mouseTargetPosition = inputControls.Mouse.Position.ReadValue<Vector2>();
            cameraController.Move(mouseOriginPosition, mouseTargetPosition);
            
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputControls inputControls;
    private InputRaycaster2D raycaster;

    [Header("Camera Movement")]
    [SerializeField] CameraController cameraController;


    [Header("Raycast Info")]
    [SerializeField] LayerMask hitLayers;
    [SerializeField] string clickableTag;

    public Vector2 MousePosition { get => inputControls.Mouse.Position.ReadValue<Vector2>();  }

    private void Awake()
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

    private void OnMiddleButtonCanceled(InputAction.CallbackContext context)
    {
        raycaster.PerformCheck(hitLayers);
        if (raycaster.HitTarget != null)
        {
            cameraController.StartDrag = false;
            cameraController.Panner.ClearDragData();
        }
    }

    private void OnMiddleButtonPerformed(InputAction.CallbackContext context)
    {
        raycaster.PerformCheck(hitLayers);
        if (raycaster.HitTarget != null)
        {
            cameraController.Panner.SetDragOrigin(inputControls.Mouse.Position.ReadValue<Vector2>());
            cameraController.StartDrag = true;
        }
    }

    private void OnWheelScrolled(InputAction.CallbackContext context)
    {
        raycaster.PerformCheck(hitLayers);
        if (raycaster.HitTarget != null)
        {
            float wheelDirection = context.ReadValue<Vector2>().normalized.y;
            Vector3 mousePosition = inputControls.Mouse.Position.ReadValue<Vector2>();

            cameraController.Zoomer.Zoom(wheelDirection, mousePosition);
        }
    }

    private void Start()
    {
        inputControls.Mouse.LeftButton.performed += OnLeftButtonClicked;

        inputControls.Mouse.MiddleButton.performed += OnMiddleButtonPerformed;
        inputControls.Mouse.MiddleButton.canceled += OnMiddleButtonCanceled;
        
        inputControls.Mouse.ScrollWheel.performed += OnWheelScrolled;
    }
}

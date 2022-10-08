using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    // [SerializeField] CameraController cameraController;
    // [SerializeField] LayerMask hitLayers;
    // [SerializeField] string clickableTag;

    public static InputController instance;
    private InputControls inputControls;
    private InputRaycaster2D raycaster;

    public bool IsLeftButtonPressed { get; private set; }
    public bool IsRightButtonPressed { get; private set; }
    public bool IsMiddleButtonPressed { get; private set; }
    public bool IsScrollWheelActive { get; private set; }
    public Vector2 MousePosition { get => inputControls.Mouse.Position.ReadValue<Vector2>();  }
    public float ScrollWheelDirection { get => inputControls.Mouse.ScrollWheel.ReadValue<Vector2>().normalized.y; }

    public InputControls Controls {
        get 
        {
            if (inputControls == null) inputControls = new InputControls();
            return inputControls;
        }
    }

    private void Awake()
    {
        inputControls = new InputControls();
        // raycaster = new InputRaycaster2D(inputControls, clickableTag);

    }

    private void OnDisable()
    {
        if (instance != null) instance = null;
        inputControls?.Disable();
    }

    private void OnEnable()
    {
        if (instance == null) instance = this;
        inputControls?.Enable();
    }

    private void Start()
    {
        inputControls.Mouse.LeftButton.performed += OnLeftButtonPerformed;
        inputControls.Mouse.LeftButton.canceled += OnLeftButtonCanceled;

        inputControls.Mouse.MiddleButton.performed += OnMiddleButtonPerformed;
        inputControls.Mouse.MiddleButton.canceled += OnMiddleButtonCanceled;
        
        // inputControls.Mouse.ScrollWheel.performed += OnScrollWheelPerformed;
        // inputControls.Mouse.ScrollWheel.canceled += OnScrollWheelCanceled;
    }

    private void OnLeftButtonPerformed(InputAction.CallbackContext ctx) => IsLeftButtonPressed = true;
    private void OnLeftButtonCanceled(InputAction.CallbackContext ctx) => IsLeftButtonPressed = false;
    private void OnMiddleButtonPerformed(InputAction.CallbackContext ctxt) => IsMiddleButtonPressed = true;
    private void OnMiddleButtonCanceled(InputAction.CallbackContext ctx) => IsMiddleButtonPressed = false;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputControls inputControls;
    private InputRaycaster2D raycaster;
    [SerializeField] LayerMask hitLayers;
    [SerializeField] string clickableTag;

    void Awake()
    {
        inputControls = new InputControls();

        raycaster = new InputRaycaster2D(inputControls, clickableTag);
    }

    private void EndedLeftClick(InputAction.CallbackContext context)
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
        inputControls.Mouse.LeftButton.performed += (InputAction.CallbackContext ctx) => EndedLeftClick(ctx);
    }
}

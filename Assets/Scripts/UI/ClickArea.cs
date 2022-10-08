using UnityEngine;
using UnityEngine.EventSystems;



public class ClickArea : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] CameraController cameraController;

    private bool IsPointerOnScreen;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(InputController.instance.IsRightButtonPressed);

        if(InputController.instance.IsMiddleButtonPressed ||
            InputController.instance.IsRightButtonPressed)
        {
            cameraController.Panner.SetDragOrigin(InputController.instance.MousePosition);
            cameraController.StartDrag = true;
        }
        else if (InputController.instance.IsLeftButtonPressed) 
        {
            // This will not be a singleton once the UI Manager is set up. Im procrastinating.
            UISelector.instance.ClearSelected();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsPointerOnScreen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsPointerOnScreen = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!InputController.instance.IsMiddleButtonPressed)
        {
            cameraController.StartDrag = false;
            cameraController.Panner.ClearDragData();
        }
    }

    private void Update()
    {
        if (InputController.instance.ScrollWheelDirection != 0)
        {
            if (IsPointerOnScreen) cameraController.Zoomer.Zoom(InputController.instance.ScrollWheelDirection, InputController.instance.MousePosition);
        }
    }
}

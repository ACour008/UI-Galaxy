using UnityEngine;
using UnityEngine.EventSystems;



public class ClickArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] CameraController cameraController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(InputController.instance.IsMiddleButtonPressed)
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
            cameraController.Zoomer.Zoom(InputController.instance.ScrollWheelDirection, InputController.instance.MousePosition);
        }
    }
}

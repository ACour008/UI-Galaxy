using UnityEngine;
using UnityEngine.EventSystems;

public class ClickArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] InputController inputController;
    [SerializeField] CameraController cameraController;
    [SerializeField] UIManager uiManager;

    private bool IsPointerOnScreen;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(inputController.IsMiddleButtonPressed)
        {
            cameraController.Panner.SetDragOrigin(inputController.MousePosition);
            cameraController.StartDrag = true;
        }
        else if (inputController.IsLeftButtonPressed) 
        {
            uiManager.OnNothingClicked();
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
        if(!inputController.IsMiddleButtonPressed)
        {
            cameraController.StartDrag = false;
            cameraController.Panner.ClearDragData();
        }
    }

    private void Update()
    {
        if (inputController.ScrollWheelDirection != 0)
        {
            if (IsPointerOnScreen) cameraController.Zoomer.Zoom(inputController.ScrollWheelDirection, inputController.MousePosition);
        }
    }
}

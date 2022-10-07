using UnityEngine;
using Conversions;

public class UISelector : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    [SerializeField] private GameObject selectionIcon;
    [SerializeField] private DialogBox dialogBox;
    [SerializeField] private Vector3 dialogOffset;
    [SerializeField] private Vector2 offScreenThreshold;
    [SerializeField] private MinMax<float> selectionSizes;
    [SerializeField] private StarSystem currentSelected;

    RectTransform iconRectTransform;
    Renderer currentSelectedRenderer;
    MinMax<Vector2> screenBoundaries;

    void Start()
    {
        iconRectTransform = selectionIcon.GetComponent<RectTransform>();
        screenBoundaries = new MinMax<Vector2>()
        {
            min = -offScreenThreshold,
            max = new Vector2(Screen.width, Screen.height) + offScreenThreshold           
        };
        ClearSelected();
    }

    public void ClearSelected(bool clearSelected = true)
    {
        selectionIcon.gameObject.SetActive(false);
        dialogBox.gameObject.SetActive(false);
        if (clearSelected)
        {
            currentSelected = null;
            currentSelectedRenderer = null;
        }
    }

    public void Star_OnClicked(object sender, OnStarSystemClickEventArgs eventArgs)
    {
        StarSystem selectedSystem = eventArgs.system;

        if (selectedSystem == currentSelected)
        {
            ClearSelected();
            return;
        }

        dialogBox.SetTexts(selectedSystem.name, selectedSystem.Government, selectedSystem.Type, selectedSystem.JumpGateCount);    
        SetSelected(selectedSystem);
    }

    private void SetSelected(StarSystem selectedSystem)
    {
        currentSelected = selectedSystem;
        currentSelectedRenderer = currentSelected.GetComponent<Renderer>();
        
        Vector3 starScale = currentSelected.transform.localScale;
        Vector3 targetPosition = uiCamera.WorldToScreenPoint(currentSelected.Position);
        float clampedX = Mathf.Clamp(starScale.x, selectionSizes.min, selectionSizes.max);
        float clampedY = Mathf.Clamp(starScale.y, selectionSizes.min, selectionSizes.max);

        iconRectTransform.localScale = new Vector3(clampedX, clampedY, 0);
        selectionIcon.transform.position = targetPosition;
        dialogBox.SetPosition(targetPosition + dialogOffset);

        selectionIcon.gameObject.SetActive(true);
        dialogBox.SetActive(true);
    }

    private void Update() {

        if(currentSelected == null || RendererIsOnScreen())
        {
            ClearSelected(false);
        }
        else
        {
            SetSelected(currentSelected);
        }
    }

    private bool RendererIsOnScreen() {
        if (currentSelectedRenderer == null) return false;

        Vector3 screenPosition = uiCamera.WorldToScreenPoint(currentSelectedRenderer.transform.position);
        
        // WHY IS THIS BACKWARDS
        if (screenPosition.x < screenBoundaries.min.x || screenPosition.x > screenBoundaries.max.x ||
            screenPosition.y < screenBoundaries.min.y || screenPosition.y > screenBoundaries.max.y) {
                return true;
            }

        return false;
    }
}

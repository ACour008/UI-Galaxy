using UnityEngine;
using Conversions;

public class UISelector : MonoBehaviour
{
    public static UISelector instance;

    [SerializeField] private Camera uiCamera;
    [SerializeField] private SolarDataHUD solarDataHUD;
    [SerializeField] private RectTransform selectionIcon;
    [SerializeField] private DialogBox dialogBox;
    [SerializeField] private Vector2 offScreenThreshold;
    [SerializeField] private MinMax<float> selectionSizes;
    [SerializeField] private StarSystem currentSelected;

    public StarSystem CurrentSystem { get => currentSelected; }
    public bool IsActive { get => isActive; }

    Canvas parentCanvas;
    RectTransform iconRectTransform;
    Renderer currentSelectedRenderer;
    MinMax<Vector2> screenBoundaries;
    bool isActive;

    void Start()
    {
        iconRectTransform = selectionIcon.GetComponent<RectTransform>();
        parentCanvas = GetComponentInParent<Canvas>();
        screenBoundaries = new MinMax<Vector2>()
        {
            min = -offScreenThreshold,
            max = new Vector2(Screen.width, Screen.height) + offScreenThreshold           
        };
        ClearSelected();
    }

    void OnEnable() {
        if (instance == null) {
            instance = this;
        }
    }

    void OnDisable() {
        if (instance != null) {
            instance = null;
        }
    }

    public void ClearSelected(bool clearSelected = true)
    {
        selectionIcon.gameObject.SetActive(false);
        dialogBox.SetActive(false);
        solarDataHUD.SetActive(false);

        if (clearSelected)
        {
            currentSelected = null;
            currentSelectedRenderer = null;
        }

        parentCanvas.sortingOrder = -1;
        isActive = false;
    }

    public void Star_OnClicked(object sender, OnStarSystemClickEventArgs eventArgs)
    {
        StarSystem selectedSystem = eventArgs.system;

        if (selectedSystem == currentSelected)
        {
            ClearSelected();
            return;
        }

        SetSelected(selectedSystem);
    }

    public void SetSelected(StarSystem selectedSystem)
    {
        currentSelected = selectedSystem;
        currentSelectedRenderer = currentSelected.GetComponent<Renderer>();

        iconRectTransform.localScale = GetScaleSize();

        SetHUDPositions();

        solarDataHUD.SetDataFrom(currentSelected);
        dialogBox.SetDataFrom(currentSelected);

        selectionIcon.gameObject.SetActive(true);
        dialogBox.SetActive(true);
        solarDataHUD.SetActive(true);

        parentCanvas.sortingOrder = 1;
        isActive = true;
    }

    private void SetHUDPositions()
    {
        selectionIcon.transform.position = currentSelected.Position; //worldspace.
        // dialogBox.SetPosition(currentSelected.Position);
        solarDataHUD.SetPosition(currentSelected.Position);
    }

    private Vector3 GetScaleSize()
    {
        // Need to account for camera ortho size.
        Vector3 starScale = currentSelected.transform.localScale;
        float clampedX = Mathf.Clamp(starScale.x, selectionSizes.min, selectionSizes.max);
        float clampedY = Mathf.Clamp(starScale.y, selectionSizes.min, selectionSizes.max);
        return new Vector3(clampedX, clampedY, 0);
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
            screenPosition.y < screenBoundaries.min.y || screenPosition.y > screenBoundaries.max.y)
        {
            return true;
        }

        return false;
    }
}

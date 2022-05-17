using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private GameObject selectionObject;
    [SerializeField] private MinMax<float> selectionSizes;

    void Start()
    {
        selectionObject.SetActive(false);
    }

    public void ClearSelected()
    {
        selectionObject.SetActive(false);
    }

    public void Star_OnClicked(object sender, OnStarSystemClickEventArgs eventArgs)
    {
        StarSystem selectedSystem = eventArgs.system;
        Vector3 starScale = selectedSystem.transform.localScale;

        float clampedX = Mathf.Clamp(starScale.x, selectionSizes.min, selectionSizes.max);
        float clampedY = Mathf.Clamp(starScale.y, selectionSizes.min, selectionSizes.max);

        selectionObject.transform.localScale = new Vector3(clampedX, clampedY, 0);
        selectionObject.transform.position = selectedSystem.Position;
        selectionObject.SetActive(true);
    }
}

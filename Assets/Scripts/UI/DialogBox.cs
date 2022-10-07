using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starName;
    [SerializeField] private TextMeshProUGUI government;
    [SerializeField] private TextMeshProUGUI systemType;
    [SerializeField] private TextMeshProUGUI jumpGateCount;

    private RectTransform rectTransform;
    private MinMax<Vector2> positionMinMax;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        float distanceX = Screen.width / 2;
        float distanceY = Screen.height / 2;

        positionMinMax = new MinMax<Vector2>() {
            min = new Vector2(-distanceX, -distanceY),
            max = new Vector2(distanceX, distanceY)
        };
    }

    public void SetActive(bool active) {
        gameObject.SetActive(active);
    }
    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
 
    public void SetTexts(string starNameText, string factionText, StarSystemType systemType, int jumpGateCount)
    {
        starName.text = starNameText;
        government.text = $"Gov't: {factionText}";
        this.systemType.text = $"System Type: {systemType.ToString()}";
        this.jumpGateCount.text = $"Jumpgate Count: {jumpGateCount.ToString()}";
    }

    private void Update()
    {
        rectTransform.anchoredPosition3D = new Vector3(
            x: Mathf.Clamp(rectTransform.anchoredPosition3D.x, positionMinMax.min.x, positionMinMax.max.x),
            y: Mathf.Clamp(rectTransform.anchoredPosition3D.y, positionMinMax.min.y, positionMinMax.max.y),
            z: rectTransform.anchoredPosition3D.z
        );
    }
}

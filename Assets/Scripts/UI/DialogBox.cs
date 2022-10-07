using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Vector3 offset;
    [SerializeField] private TextMeshProUGUI systemType;
    [SerializeField] private TextMeshProUGUI jumpGateCount;
    [SerializeField] private TextMeshProUGUI age;

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
        transform.position = newPosition + offset;
    }
 
    public void SetDataFrom(StarSystem starSystem)
    {
        this.systemType.text = starSystem.Type.ToString();
        this.jumpGateCount.text = starSystem.JumpGateCount.ToString();
        this.age.text = Utils.Conversions.ConvertNumber(starSystem.Age, 1e9);
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

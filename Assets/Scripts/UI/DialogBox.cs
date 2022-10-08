using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Can make this abstract, in which this particular object inherets from. 
// The show method should have a payload property that takes the star and places the data accordingly.
public class DialogBox : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Vector3 offset;
    [SerializeField] private TextMeshProUGUI systemType;
    [SerializeField] private TextMeshProUGUI jumpGateCount;
    [SerializeField] private TextMeshProUGUI age;
    [SerializeField] private TextMeshProUGUI solarRadius;


    private RectTransform rectTransform;
    private MinMax<Vector2> positionBoundary;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // float allowableWidth = (Screen.width / 2) - (rectTransform.rect.width / 2) - 50f;
        // float allowableHeight = (Screen.height / 2) - (rectTransform.rect.height / 2) - 50f;

        // positionBoundary = new MinMax<Vector2>() {
        //     min = new Vector2(-allowableWidth, -allowableHeight),
        //     max = new Vector2(allowableWidth, allowableHeight)
        // };
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
        this.solarRadius.text = starSystem.Radius.ToString();
    }

    // private void Update()
    // {
    //     rectTransform.anchoredPosition3D = new Vector3(
    //         x: Mathf.Clamp(rectTransform.anchoredPosition3D.x, positionBoundary.min.x, positionBoundary.max.x),
    //         y: Mathf.Clamp(rectTransform.anchoredPosition3D.y, positionBoundary.min.y, positionBoundary.max.y),
    //         z: rectTransform.anchoredPosition3D.z
    //     );
    // }
}

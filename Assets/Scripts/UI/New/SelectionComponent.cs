using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionComponent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starName;
    [SerializeField] private TextMeshProUGUI government;

    public void SetData(StarSystem star)
    {
        starName.text = star.name;
        government.text = star.Government;
    }
}

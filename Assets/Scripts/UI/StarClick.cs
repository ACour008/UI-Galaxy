using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarClick : MonoBehaviour, IPointerClickHandler
{
    StarSystem star;

    private void Start()
    {
        star = GetComponent<StarSystem>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UIManager.instance.selectedSystem != star)
        {
            UIManager.instance.OnStarClicked(star);
        }
    }
}

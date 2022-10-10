using UnityEngine;
using UnityEngine.EventSystems;

public class StarClick : MonoBehaviour, IPointerClickHandler
{
    StarSystem star;

    public StarClickDelegate starClicked;

    private void Start()
    {
        star = GetComponent<StarSystem>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        starClicked?.Invoke(star);
    }
}

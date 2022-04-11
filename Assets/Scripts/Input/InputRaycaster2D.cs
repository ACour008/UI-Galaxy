using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rename;
public class InputRaycaster2D
{
    private InputControls inputControls;
    private IRayProvider rayProvider;
    private string clickableTag;
    private GameObject _hitTarget;

    public GameObject HitTarget { get => _hitTarget; }

    public InputRaycaster2D(InputControls controls, string clickableTag)
    {
        this.clickableTag = clickableTag;
        inputControls = controls;
        rayProvider = new Ray2DProvider();
    }

    public void PerformCheck(LayerMask layers)
    {
        _hitTarget = null;

        Ray ray = rayProvider.GetRay(inputControls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.transform != null && hit.transform.CompareTag(clickableTag))
        {
            _hitTarget = hit.transform.gameObject;
        }
    }
}
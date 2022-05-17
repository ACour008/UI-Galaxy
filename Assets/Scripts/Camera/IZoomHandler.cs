using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZoomHandler: ICamInitializer
{
    public void OnZoomClick(float direction);
    public void SetZoomLevel(float zoomRate);
    public void Zoom(float direction, Vector2 mousePosition);
    public void ZoomInBy(float scaleFactor, Vector2 mousePosition);
    public void ZoomOutBy(float scaleFactor, Vector2 mousePosition);

}

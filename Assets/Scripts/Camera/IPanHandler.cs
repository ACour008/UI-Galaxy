using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanHandler: ICamInitializer
{
    public void ClearDragData();
    public void Pan(Vector2 mousePosition);
    public void SetDragOrigin(Vector2 mousePosition);
}

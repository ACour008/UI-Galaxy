using UnityEngine;

internal class Ray2DProvider : IRayProvider
{
    public Ray GetRay(Vector2 position) => Camera.main.ScreenPointToRay(position);
}
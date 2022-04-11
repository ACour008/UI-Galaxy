using UnityEngine;

internal interface IRayProvider
{
    public Ray GetRay(Vector2 position);
}
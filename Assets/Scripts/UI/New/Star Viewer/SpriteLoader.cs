using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;


    public Sprite LoadSprite(int i)
    {
        return sprites[i];
    } 
}

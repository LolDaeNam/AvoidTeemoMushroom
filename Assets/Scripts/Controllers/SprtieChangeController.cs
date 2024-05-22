using System;
using UnityEngine;

public class SprtieChangeController : MonoBehaviour
{
    public Sprite[] sprites;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    public void SpriteChange(int index)
    {
        spriteRenderer.sprite = sprites[index];
    }
}

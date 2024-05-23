using UnityEngine;

public class SpriteChangeController : MonoBehaviour
{
    public Sprite[] sprites;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    // 스프라이트 변경
    public void SpriteChange(int index)
    {
        spriteRenderer.sprite = sprites[index];
    }
}

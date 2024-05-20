using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void Start()
    {
        ItemManager.Instance.ItemEvent += ItemEffect;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Invincible"))
        {
            ItemManager.Instance.UseItem(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public abstract void ItemEffect(GameObject player);
}

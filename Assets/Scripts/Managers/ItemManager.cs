using System;
using System.Collections;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public event Action<GameObject> ItemEvent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UseItem(GameObject player)
    {
        ItemEvent?.Invoke(player);
    }

    public void InvincibleItemAfterEffect(GameObject player)
    {
        StartCoroutine("ResetInvincibility", player);
    }

    public IEnumerator ResetInvincibility(GameObject player)
    {
        yield return new WaitForSeconds(5f);
        player.tag = "Player";
        player.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}

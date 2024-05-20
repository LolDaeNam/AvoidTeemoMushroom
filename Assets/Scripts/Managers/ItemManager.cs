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

    // 이벤트에 등록된 아이템 효과 사용
    public void UseItem(GameObject player)
    {
        ItemEvent?.Invoke(player);
        ItemEvent = null;
    }

    // 무적 아이템 후처리
    public void InvincibleItemAfterEffect(GameObject player)
    {
        StartCoroutine("ResetInvincibility", player);
    }

    public IEnumerator ResetInvincibility(GameObject player)
    {
        // 무적 상태 5초 유지 후 원상복귀
        yield return new WaitForSeconds(5f);
        player.tag = "Player";
        player.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}

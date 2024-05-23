using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public event Action<GameObject> ItemEvent;  // 아이템 효과 이벤트

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // 이벤트에 등록된 아이템 효과 사용
    public void UseItem(GameObject player)
    {
        ItemEvent?.Invoke(player);
        DestroyedItem();    // 아이템 소모
    }
    
    // 아이템이 소모되었을 경우 이벤트 비워주기
    public void DestroyedItem()
    {
        ItemEvent = null;
    }

    // 무적 아이템 후처리 (코루틴)
    public void InvincibleItemAfterEffect(GameObject player)
    {
        StartCoroutine("ResetInvincibility", player);
    }

    public IEnumerator ResetInvincibility(GameObject player)
    {
        // 무적 상태 5초 유지
        yield return new WaitForSecondsRealtime(5f);
        // 무적 해제
        player.tag = "Player";
        // 애니메이션 기본 상태
        player.GetComponent<Animator>().Play("New State");
        // 플레이어 입력 활성화
        player.GetComponent<PlayerInput>().enabled = true;
    }
}

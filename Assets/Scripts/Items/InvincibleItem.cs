using UnityEngine;

public class InvincibleItem : Item
{
    public override void ItemEffect(GameObject player)
    {
        // 플레이어 무적
        SetInvincibility(player);
    }

    public void SetInvincibility(GameObject player)
    {
        // 플레이어의 태그를 변경시켜서 충돌이 일어나지 않도록 함
        player.tag = "Invincible";
        // 시각적 효과(투명화)
        player.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        // 이후 처리를 아이템 매니저에서 함
        ItemManager.Instance.InvincibleItemAfterEffect(player);
    }
}

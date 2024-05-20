using UnityEngine;

public class InvincibleItem : Item
{
    public override void ItemEffect(GameObject player)
    {
        SetInvincibility(player);
    }

    public void SetInvincibility(GameObject player)
    {
        player.tag = "Invincible";
        player.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        ItemManager.Instance.InvincibleItemAfterEffect(player);
    }
}

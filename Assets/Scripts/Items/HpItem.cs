using UnityEngine;

public class HpItem : Item
{
    private readonly int recoverAmount = 30;

    public override void ItemEffect(GameObject player)
    {
        RestoreHp(player);
    }

    public void RestoreHp(GameObject player)
    {
        player.GetComponentInChildren<PlayerHealthSystem>().RecoverHp(recoverAmount);
    }
}

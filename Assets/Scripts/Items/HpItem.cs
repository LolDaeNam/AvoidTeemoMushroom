using UnityEngine;

public class HpItem : Item
{
    private readonly int recoverAmount = 30; // 체력 회복량

    public override void ItemEffect(GameObject player)
    {
        // HP 회복
        RestoreHp(player);
    }

    public void RestoreHp(GameObject player)
    {
        // HealthSystem에서 주어진 HP 회복량만큼 회복
        player.GetComponentInChildren<PlayerHealthSystem>().RecoverHp(recoverAmount);
    }
}

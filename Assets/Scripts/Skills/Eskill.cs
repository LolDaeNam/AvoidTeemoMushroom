using Unity.VisualScripting;
using UnityEngine;

public class Eskill : AbstractSkill
{
    public PlayerHealthSystem healthSystem;

    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 0f;
        }
        GameManager.Instance.isActiveSckill = true;
    }

    public override void Deactivate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 1f;
        }
        GameManager.Instance.isActiveSckill = false;
    }
}

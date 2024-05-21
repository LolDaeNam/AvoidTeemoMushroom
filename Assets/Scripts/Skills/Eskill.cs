using Unity.VisualScripting;
using UnityEngine;

public class Eskill : AbstractSkill
{
    public PlayerHealthSystem healthSystem;
    public SprtieChangeController spriteChangeController;

    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 0f;
        }
        spriteChangeController.SpriteChange(1);
        GameManager.Instance.isActiveSkill = true;
        
    }

    public override void Deactivate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 1f;
        }
        spriteChangeController.SpriteChange(0);
        GameManager.Instance.isActiveSkill = false;
    }
}

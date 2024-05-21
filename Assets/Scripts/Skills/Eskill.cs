using Unity.VisualScripting;
using UnityEngine;

public class Eskill : AbstractSkill
{
    PlayerAnimationContorller playerAnimation;
    public PlayerHealthSystem healthSystem;
    public SprtieChangeController spriteChangeController;
    public GameObject Sword;

    private void Start()
    {
        
    }

    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        playerAnimation = player.GetComponent<PlayerAnimationContorller>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 0f;
        }
        spriteChangeController.SpriteChange(1);
        GameManager.Instance.isActiveSkill = true;
        Sword.SetActive(true);
        playerAnimation.OnSkillHit();
        
    }

    public override void Deactivate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        playerAnimation = player.GetComponent<PlayerAnimationContorller>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 1f;
        }
        spriteChangeController.SpriteChange(0);
        GameManager.Instance.isActiveSkill = false;
        Sword.SetActive(false);
        playerAnimation.OutSkillHit();
    }
}

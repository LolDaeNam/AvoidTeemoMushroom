using Unity.VisualScripting;
using UnityEngine;

public class Eskill : AbstractSkill
{
    PlayerAnimationContorller playerAnimation;
    public PlayerHealthSystem healthSystem;
    public SprtieChangeController spriteChangeController;
    public GameObject Sword;

    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        playerAnimation = player.GetComponent<PlayerAnimationContorller>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 0f;
        }
        spriteChangeController.SpriteChange(1);
        GameManager.Instance.isActiveEskill = true;
        Sword.SetActive(true);
        playerAnimation.OnEskillAnim();
        AudioManager.Instance.GarenSkillSound(2);
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
        GameManager.Instance.isActiveEskill = false;
        Sword.SetActive(false);
        playerAnimation.OutEskillAnim();
    }
}

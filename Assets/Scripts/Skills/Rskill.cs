using UnityEngine;

public class Rskill : AbstractSkill
{
    [HideInInspector]
    public GameObject currentObject;
    public GameObject rskillMotion;
    PlayerAnimationContorller playerAnimation;
    PlayerMovement playerMovement;
    PlayerHealthSystem healthSystem;

    public override void Activate(GameObject player)
    {
        playerAnimation = player.GetComponent<PlayerAnimationContorller>();
        playerMovement = player.GetComponent<PlayerMovement>();
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 0f;
        }
        GameManager.Instance.isActiveRskill = true;
        currentObject = Instantiate(rskillMotion, new Vector3(0, 15, 0), Quaternion.identity);
        playerAnimation.OnRskillAnim();
        playerMovement.controller.OnMoveEvent -= playerMovement.Move;
        playerMovement.speed = 0f;
        AudioManager.Instance.GarenSkillSound(3);
    }

    public override void Deactivate(GameObject player)
    {
        playerAnimation = player.GetComponent<PlayerAnimationContorller>();
        playerMovement = player.GetComponent<PlayerMovement>();
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 1f;
        }
        GameManager.Instance.isActiveRskill = false;
        Destroy(currentObject);
        playerAnimation.OutRskillAnim();
        playerMovement.controller.OnMoveEvent += playerMovement.Move;
        playerMovement.speed = 5f;
    }
}

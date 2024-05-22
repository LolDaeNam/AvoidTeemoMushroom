using UnityEngine;

public class Rskill : AbstractSkill
{
    [HideInInspector]
    public GameObject currentObject;
    public GameObject rskillMotion;
    PlayerAnimationContorller playerAnimation;
    PlayerMovement playerMovement;

    public override void Activate(GameObject player)
    {
        playerAnimation = player.GetComponent<PlayerAnimationContorller>();
        playerMovement = player.GetComponent<PlayerMovement>();
        GameManager.Instance.isActiveRskill = true;
        currentObject = Instantiate(rskillMotion, new Vector3(0, 15, 0), Quaternion.identity);
        playerAnimation.OnRskill();
        playerMovement.controller.OnMoveEvent -= playerMovement.Move;
    }

    public override void Deactivate(GameObject player)
    {
        playerAnimation = player.GetComponent<PlayerAnimationContorller>();
        playerMovement = player.GetComponent<PlayerMovement>();
        GameManager.Instance.isActiveRskill = false;
        Destroy(currentObject);
        playerAnimation.OutRskill();
        playerMovement.controller.OnMoveEvent += playerMovement.Move;
    }
}

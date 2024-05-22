using UnityEngine;

public class Wskill : AbstractSkill
{
    public PlayerHealthSystem healthSystem;
    public GameObject shield;

    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null )
        {
            healthSystem.damageReduction = 0.5f;
        }
        shield.SetActive(true);
        AudioManager.Instance.GarenSkillSound(1);
    }

    public override void Deactivate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 1f;
        }
        shield.SetActive(false);
    }
}

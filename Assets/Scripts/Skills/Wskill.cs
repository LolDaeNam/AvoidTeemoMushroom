using UnityEngine;

public class Wskill : AbstractSkill
{
    public PlayerHealthSystem healthSystem;

    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if(healthSystem != null )
        {
            healthSystem.damageReduction *= 0.5f;
        }
    }

    public override void Deactivate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction *= 2f;
        }
    }
}

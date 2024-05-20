public class Qskill : AbstractSkill
{
    PlayerMovement playerMovement;

    public float speedMultiplier = 2f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        cooldownTime = 8f;
        activeTime = 5f;
    }

    public override void Activate()
    {
        if (playerMovement != null)
        {
            playerMovement.speed *= speedMultiplier;
        }
    }

    public override void Deactivate()
    {
        if(playerMovement != null)
        {
            playerMovement.speed /= speedMultiplier;
        }
    }
}

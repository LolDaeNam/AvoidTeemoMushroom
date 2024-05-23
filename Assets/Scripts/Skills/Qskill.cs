using UnityEngine;

public class Qskill : AbstractSkill
{
    PlayerMovement playerMovement;

    public float speedMultiplier = 2f;  // 이동속도 배수

    // 스킬 사용
    public override void Activate(GameObject player)
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        // 플레이어 속도 조정
        if (playerMovement != null)
        {
            playerMovement.speed *= speedMultiplier;
        }
        AudioManager.Instance.GarenSkillSound(0);
    }

    // 스킬 사용 종료
    public override void Deactivate(GameObject player)
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        // 원상 복귀
        if (playerMovement != null)
        {
            playerMovement.speed /= speedMultiplier;
        }
    }
}

using UnityEngine;

public class Wskill : AbstractSkill
{
    public PlayerHealthSystem healthSystem;     // HP 시스템
    public GameObject shield;                   // 방패 오브젝트

    // 스킬 사용
    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        // 받는 데미지 50% 감소
        if (healthSystem != null )
        {
            healthSystem.damageReduction = 0.5f;
        }
        // 방패 오브젝트 활성화
        shield.SetActive(true);
        // 스킬 사운드 출력
        AudioManager.Instance.GarenSkillSound(1);
    }

    // 스킬 사용 종료
    public override void Deactivate(GameObject player)
    {
        // 원상 복귀
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 1f;
        }
        shield.SetActive(false);
    }
}

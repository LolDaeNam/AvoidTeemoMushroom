using UnityEngine;

public class Rskill : AbstractSkill
{
    [HideInInspector]
    public GameObject currentObject;                    // 임시 오브젝트
    public GameObject rskillMotion;                     // R스킬 모션
    PlayerAnimationController playerAnimation;          // 플레이어 캐릭터 애니메이션
    PlayerMovement playerMovement;                      // 플레이어 이동
    PlayerHealthSystem healthSystem;                    // HP 시스템

    // 스킬 사용
    public override void Activate(GameObject player)
    {
        playerAnimation = player.GetComponent<PlayerAnimationController>();
        playerMovement = player.GetComponent<PlayerMovement>();
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        // 피격 시 데미지 받지 않음
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 0f;
        }
        // 스킬 사용 표시
        GameManager.Instance.isActiveRskill = true;
        // 애니메이션 출력
        currentObject = Instantiate(rskillMotion, new Vector3(0, 15, 0), Quaternion.identity);
        playerAnimation.OnRskillAnim();
        // 이동 불가
        playerMovement.controller.OnMoveEvent -= playerMovement.Move;
        playerMovement.speed = 0f;
        // 사운드 출력
        AudioManager.Instance.GarenSkillSound(3);
    }

    // 스킬 사용 종료
    public override void Deactivate(GameObject player)
    {
        playerAnimation = player.GetComponent<PlayerAnimationController>();
        playerMovement = player.GetComponent<PlayerMovement>();
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        // 원상 복귀
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

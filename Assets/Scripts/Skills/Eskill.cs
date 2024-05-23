using UnityEngine;

public class Eskill : AbstractSkill
{
    PlayerAnimationController playerAnimation;              // 플레이어 애니메이션
    public PlayerHealthSystem healthSystem;                 // HP 시스템
    public SpriteChangeController spriteChangeController;   // 스프라이트 변경
    public GameObject Sword;                                // 검 오브젝트
    
    // 스킬 사용
    public override void Activate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        playerAnimation = player.GetComponent<PlayerAnimationController>();
        // 피격 시 데미지 받지 않음
        if (healthSystem != null)
        {
            healthSystem.damageReduction = 0f;
        }
        // 검을 잡는 모션 적용
        spriteChangeController.SpriteChange(1);
        // E스킬 사용 중 표시
        GameManager.Instance.isActiveEskill = true;
        // 검 오브젝트 활성화
        Sword.SetActive(true);
        // 검을 잡고 빙글빙글 도는 애니메이션 출력
        playerAnimation.OnEskillAnim();
        // 스킬 사운드 출력
        AudioManager.Instance.GarenSkillSound(2);
    }

    // 스킬 사용 종료
    public override void Deactivate(GameObject player)
    {
        healthSystem = player.GetComponent<PlayerHealthSystem>();
        playerAnimation = player.GetComponent<PlayerAnimationController>();
        // 원상 복귀
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

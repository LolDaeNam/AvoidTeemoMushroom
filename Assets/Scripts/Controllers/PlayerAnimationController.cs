using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    protected Animator animator;

    private static readonly int isHit = Animator.StringToHash("isHit");         // 피격 여부
    private static readonly int isSkill = Animator.StringToHash("isSkill");     // E스킬 사용 여부
    private static readonly int isRskill = Animator.StringToHash("isRskill");   // R스킬 사용 여부

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // 피격 시 애니메이션 출력
    public void OnHitAnim()
    {
        animator.SetBool(isHit, true);
    }

    public void OutHitAnim()
    {
        animator.SetBool(isHit, false);
    }

    // E스킬 사용 시 애니메이션 출력
    public void OnEskillAnim()
    {
        animator.SetBool(isSkill, true);
    }

    public void OutEskillAnim()
    {
        animator.SetBool(isSkill, false);
    }

    // R스킬 사용 시 애니메이션 출력
    public void OnRskillAnim()
    {
        animator.SetBool(isRskill, true);
    }

    public void OutRskillAnim()
    {
        animator.SetBool(isRskill, false);
    }
}

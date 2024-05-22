using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAnimationContorller : MonoBehaviour
{
    protected Animator animator;

    private static readonly int isHit = Animator.StringToHash("isHit");
    private static readonly int isSkill = Animator.StringToHash("isSkill");
    private static readonly int isRskill = Animator.StringToHash("isRskill");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnHitAnim()
    {
        animator.SetBool(isHit, true);
    }

    public void OutHitAnim()
    {
        animator.SetBool(isHit, false);
    }

    public void OnEskillAnim()
    {
        animator.SetBool(isSkill, true);
    }

    public void OutEskillAnim()
    {
        animator.SetBool(isSkill, false);
    }

    public void OnRskillAnim()
    {
        animator.SetBool(isRskill, true);
    }

    public void OutRskillAnim()
    {
        animator.SetBool(isRskill, false);
    }
}

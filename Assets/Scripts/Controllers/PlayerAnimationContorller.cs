using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAnimationContorller : MonoBehaviour
{
    protected Animator animator;

    private static readonly int isHit = Animator.StringToHash("isHit");
    private static readonly int isSkill = Animator.StringToHash("isSkill");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnAnimHit()
    {
        animator.SetBool(isHit, true);
    }

    public void OutAnimHit()
    {
        animator.SetBool(isHit, false);
    }

    public void OnSkillHit()
    {
        animator.SetBool(isSkill, true);
    }

    public void OutSkillHit()
    {
        animator.SetBool(isSkill, false);
    }
}

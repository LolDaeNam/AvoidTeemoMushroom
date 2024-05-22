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

    public void OnAnimHit()
    {
        animator.SetBool(isHit, true);
    }

    public void OutAnimHit()
    {
        animator.SetBool(isHit, false);
    }

    public void OnEskill()
    {
        animator.SetBool(isSkill, true);
    }

    public void OutEskill()
    {
        animator.SetBool(isSkill, false);
    }

    public void OnRskill()
    {
        animator.SetBool(isRskill, true);
    }

    public void OutRskill()
    {
        animator.SetBool(isRskill, false);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAnimationContorller : MonoBehaviour
{
    protected Animator animator;

    private static readonly int isHit = Animator.StringToHash("isHit");

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
}

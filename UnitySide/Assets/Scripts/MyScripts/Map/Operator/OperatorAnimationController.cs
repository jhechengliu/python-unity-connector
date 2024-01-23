using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OperatorAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private static class Animations
    {
        public const string RUN = "Rifle Run";
        public const string JUMP = "Jumping";
        public const string IDLE = "Rifle Idle";
        public const string SHOOT = "GunPlay";
        public const string DEATH = "Death";
    }

    public void PlayRunAnimation()
    {
        animator.Play(Animations.RUN);
    }

    public void PlayIdleAnimation()
    {
        animator.Play(Animations.IDLE);
    }

    public void PlayDeathAnimation()
    {
        animator.applyRootMotion = true;
        animator.Play(Animations.DEATH);
    }

    public void PlayJumpAnimation()
    {
        animator.Play(Animations.JUMP);
    }
}

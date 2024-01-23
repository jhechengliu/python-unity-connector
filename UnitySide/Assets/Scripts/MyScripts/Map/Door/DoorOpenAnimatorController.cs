using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class DoorOpenAnimatorController : MonoBehaviour
{
    private static class Animations
    {
        public const string CLOSE_IDLE = "CloseIdle";
        public const string OPEN_IDLE = "OpenIdle";
        public const string OPEN_IDLE_NEGATIVE = "OpenIdleNegative";
        public const string OPEN_ANIMATION = "OpenAnimation";
        public const string CLOSE_ANIMATION = "CloseAnimation";
        public const string OPEN_ANIMATION_NEGATIVE = "OpenAnimationNegative";
        public const string CLOSE_ANIMATION_NEGATIVE = "CloseAnimationNegative";
    }

    [SerializeField]
    Animator animator;

    private bool negative = false;

    public void PlayOpenPositiveAnimation()
    {
        animator.Play(Animations.OPEN_ANIMATION);
    }

    public void PlayOpenNegativeAnimation()
    {
        animator.Play(Animations.OPEN_ANIMATION_NEGATIVE);
        negative = true;
    }

    public void PlayCloseAnimation()
    {
        if (negative == false)
        {
            animator.Play(Animations.CLOSE_ANIMATION);
        }
        else if (negative == true)
        {
            animator.Play(Animations.CLOSE_ANIMATION_NEGATIVE);
        }
        else
        {
            animator.Play(Animations.CLOSE_IDLE);
        }
        
        negative = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOverEvent : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Fireball", false);
        var shoot = FindObjectOfType<Shoot>();
        shoot.recentlyShot = false;
        shoot.Fire();
    }
}

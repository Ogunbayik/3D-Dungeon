using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController 
{
    private Animator _animator;
    public AnimationController(Animator animator) => _animator = animator;
    public void PlayAnimation(int animationHash, float transitionTime) => _animator.CrossFade(animationHash, transitionTime);
    public bool IsAnimationFinished(int layer = 0)
    {
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return stateInfo.normalizedTime >= 1.0f && !_animator.IsInTransition(layer);
    }
}

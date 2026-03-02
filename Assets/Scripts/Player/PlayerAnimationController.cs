using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController 
{
    private Animator _animator;
    public PlayerAnimationController(Animator animator) => _animator = animator;
    public void PlayAnimation(int animationHash, float transitionTime) => _animator.CrossFade(animationHash, transitionTime);
}

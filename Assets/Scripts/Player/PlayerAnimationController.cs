using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private void Awake() => _animator = GetComponent<Animator>();
    public void PlayMovementAnimation(float moveSpeed) => _animator.SetFloat(GameConstant.PlayerAnimationData.SPEED_HASH, moveSpeed);
    public void PlayJumpAnimation() => _animator.SetTrigger(GameConstant.PlayerAnimationData.JUMP_HASH);
}

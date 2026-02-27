using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private void Awake() => _animator = GetComponent<Animator>();
    public void PlayMovementAnimation(float moveSpeed) => _animator.SetFloat(GameConstant.PlayerAnimationData.SPEED_HASH, moveSpeed);
    public void PlayMovementBlendAnimation(float moveX, float moveZ)
    {
        _animator.SetFloat(GameConstant.PlayerAnimationData.BLENDX_HASH, moveX);
        _animator.SetFloat(GameConstant.PlayerAnimationData.BLENDZ_HASH, moveZ);
    }
}

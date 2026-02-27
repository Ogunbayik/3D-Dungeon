using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Header("Ground Check Settings")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _checkLayer;

    private IInputService _input;

    private PlayerData _data;

    private CharacterController _characterController;
    private PlayerAnimationController _animationControler;

    private float _velocityY;
    private bool _isGrounded;
    private bool _isPressedJump;

    [Inject]
    public void Construct(IInputService input, PlayerData data)
    {
        _input = input;
        _data = data;
    }
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animationControler = GetComponent<PlayerAnimationController>();
    }
    private void Update() => HandleMovement();
    private void HandleMovement()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _checkRadius, _checkLayer);

        var horizontal = _input.HorizontalInput();
        var vertical = _input.VerticalInput();

        var inputVector = new Vector3(horizontal, 0f, vertical);
        var movementDirection = Vector3.ClampMagnitude(inputVector, 1f);

        if (_isGrounded && _velocityY < 0f)
            _velocityY = _data.GroundedGravity;

        if (_input.PressedJump())
            _isPressedJump = true;

        if(_isGrounded)
        {
            if(_isPressedJump)
            {
                _velocityY = Mathf.Sqrt(_data.JumpHeight * GameConstant.GameSettings.JumpGravityCoefficient * Physics.gravity.y);
                _animationControler.PlayJumpAnimation();
                _isPressedJump = false;
            }
        }
        else
        {
            _isPressedJump = false;
            _velocityY += Physics.gravity.y * _data.GravityMultiplier * Time.deltaTime;
        }

        _velocityY += Physics.gravity.y * Time.deltaTime;
        Vector3 finalMovement = movementDirection * _data.MovementSpeed;
        finalMovement.y = _velocityY;

        _characterController.Move(finalMovement * Time.deltaTime);

        _animationControler.PlayMovementAnimation(movementDirection.magnitude);
        _animationControler.PlayMovementBlendAnimation(horizontal, vertical);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(_groundCheck.position, _checkRadius);
    }
}

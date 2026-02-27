using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IInputService _input;

    private PlayerData _data;

    private CharacterController _characterController;
    private PlayerAnimationController _animationControler;

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
        var horizontal = _input.HorizontalInput();
        var vertical = _input.VerticalInput();

        var inputVector = new Vector3(horizontal, 0f, vertical);
        var movementDirection = Vector3.ClampMagnitude(inputVector, 1f);
        Vector3 finalMovement = movementDirection * _data.MovementSpeed;
        
        _characterController.Move(finalMovement * Time.deltaTime);

        _animationControler.PlayMovementAnimation(movementDirection.magnitude);
        _animationControler.PlayMovementBlendAnimation(horizontal, vertical);
    }
}

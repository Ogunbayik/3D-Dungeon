using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private IInputService _input;

    private PlayerData _data;

    private CharacterController _characterController;

    private Vector3 _movementDirection;

    [Inject]
    public void Construct(IInputService input, PlayerData data)
    {
        _input = input;
        _data = data;
    }

    private void Awake() => _characterController = GetComponent<CharacterController>();
        
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var horizontal = _input.HorizontalInput();
        var vertical = _input.VerticalInput();

        _movementDirection.Set(horizontal, 0f, vertical);
        _characterController.SimpleMove(_movementDirection * _data.MovementSpeed);
    }
}

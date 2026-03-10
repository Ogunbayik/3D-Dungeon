using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : IInputService
{
    public float HorizontalInput() => Input.GetAxis(GameConstant.PlayerInput.HORIZONTAL_INPUT);
    public float VerticalInput() => Input.GetAxis(GameConstant.PlayerInput.VERTICAL_INPUT);
    public bool PressedJump() => Input.GetKeyDown(KeyCode.Space);
    public bool PressedAttack() => Input.GetMouseButtonDown(0);
    public bool PressedCombatMode() => Input.GetKeyDown(KeyCode.C);
    public bool PressedInteract() => Input.GetKeyDown(KeyCode.E);
}

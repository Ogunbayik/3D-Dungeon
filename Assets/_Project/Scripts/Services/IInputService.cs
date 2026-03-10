using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    float HorizontalInput();
    float VerticalInput();
    bool PressedJump();
    bool PressedAttack();
    bool PressedCombatMode();
    bool PressedInteract();
}

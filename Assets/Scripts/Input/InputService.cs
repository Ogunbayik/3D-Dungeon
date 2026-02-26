using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : IInputService
{
    public float HorizontalInput() => Input.GetAxis(GameConstant.PlayerInput.HORIZONTAL_INPUT);
    public float VerticalInput() => Input.GetAxis(GameConstant.PlayerInput.VERTICAL_INPUT);
}

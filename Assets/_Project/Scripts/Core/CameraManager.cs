using Cinemachine;
using MyGame.Core.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Camera References")]
    [SerializeField] private CinemachineVirtualCamera _gameCamera;
    [SerializeField] private CinemachineVirtualCamera _combatCamera;
    [SerializeField] private CinemachineVirtualCamera _deadCamera;
    private void Start() => Initialize();
    private void Initialize()
    {
        _gameCamera.Priority = GameConstant.CameraSettings.ACTIVE_PRIORITY;
        _combatCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;
        _deadCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;
    }
    public void ToggleCamera(GameSignal.OnPlayerModeChangedSignal signal)
    {
        _gameCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;
        _combatCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;
        _deadCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;

        switch(signal.NewMode)
        {
            case PlayerMode.Exploration:
                _gameCamera.Priority = GameConstant.CameraSettings.ACTIVE_PRIORITY;
                break;
            case PlayerMode.Combat:
                _combatCamera.Priority = GameConstant.CameraSettings.ACTIVE_PRIORITY;
                break;
            case PlayerMode.Death:
                _deadCamera.Priority = GameConstant.CameraSettings.ACTIVE_PRIORITY;
                break;
        }
    }
}

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
    private void Start() => Initialize();
    private void Initialize()
    {
        _gameCamera.Priority = GameConstant.CameraSettings.ACTIVE_PRIORITY;
        _combatCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;
    }
    public void ToggleCamera(GameSignal.OnPlayerModeChangedSignal signal)
    {
        if(signal.NewMode == PlayerMode.Exploration)
        {
            _gameCamera.Priority = GameConstant.CameraSettings.ACTIVE_PRIORITY;
            _combatCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;
        }
        else
        {
            _gameCamera.Priority = GameConstant.CameraSettings.DEACTIVE_PRIORITY;
            _combatCamera.Priority = GameConstant.CameraSettings.ACTIVE_PRIORITY;
        }
    }
}

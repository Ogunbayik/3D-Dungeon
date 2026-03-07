using MyGame.Core.Enums;
using UnityEngine;
using Zenject;

public class PlayerBase : MonoBehaviour
{
    [Header("Visual References")]
    [SerializeField] private Transform _bodyVisual;
    [Header("Ground Check Settings")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _checkLayer;
    [Header("Attack Check Settings")]
    [SerializeField] private Transform _attackCheck;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _attackLayer;

    private SignalBus _signalBus;

    private IInputService _input;

    private PlayerData _data;

    private PlayerMode _currentMode;

    private CharacterController _characterController;
    private AnimationController _animationControler;

    private float _velocityY;
    public float VelocityY => _velocityY;
    public PlayerData Data => _data;
    public AnimationController AnimationControler => _animationControler;

    public PlayerMode CurrentMode => _currentMode;

    [Inject]
    public void Construct(IInputService input, PlayerData data, AnimationController animationController, SignalBus signalBus)
    {
        _input = input;
        _data = data;
        _animationControler = animationController;
        _signalBus = signalBus;
    }
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _currentMode = PlayerMode.Exploration;
    }
    private void Update()
    {
        if (PressedCombatMode())
        {
            _currentMode = (_currentMode == PlayerMode.Exploration) ? PlayerMode.Combat : PlayerMode.Exploration;
            _signalBus.Fire(new GameSignal.OnPlayerModeChangedSignal(_currentMode));
        }
    }
    public void ApplyGravity()
    {
        if (IsGrounded() && _velocityY <= 0)
            _velocityY = _data.GroundedGravity;
        else
            _velocityY += Physics.gravity.y * _data.GravityMultiplier * Time.deltaTime;
    }
    public void HandleJump() => _velocityY = Mathf.Sqrt(_data.JumpHeight * GameConstant.GameSettings.JUMPGRAVITYCOEFFICIENT * Physics.gravity.y);
    public void Move(Vector3 movementDirection)
    {
        Vector3 finalMovement = movementDirection * _data.MovementSpeed;
        finalMovement.y = _velocityY;

        _characterController.Move(finalMovement * Time.deltaTime);

        HandleMoveRotation();
    }
    private void HandleMoveRotation()
    {
        var direction = GetInputDirection();

        if (direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            _bodyVisual.rotation = Quaternion.Slerp(_bodyVisual.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
        }
    }
    public bool PressedCombatMode() => _input.PressedCombatMode();
    public bool PressedAttack() => _input.PressedAttack();
    public bool PressedJump() => _input.PressedJump();
    public bool IsGrounded() => Physics.CheckSphere(_groundCheck.position, _checkRadius, _checkLayer);
    public EnemyHealthController HasValidTarget()
    {
        Collider[] hitColliders = new Collider[1];
        int enemyColliders = Physics.OverlapSphereNonAlloc(_attackCheck.position, _attackRadius, hitColliders, _attackLayer);

        if (enemyColliders > 0)
        {
            return hitColliders[0].GetComponent<EnemyHealthController>();
        }

        return null;
    }
    public bool IsMoving()
    {
        var inputDirection = GetInputDirection();

        return inputDirection.magnitude > 0.1f;
    }
    public Vector3 GetInputDirection()
    {
        var horizontal = _input.HorizontalInput();
        var vertical = _input.VerticalInput();
        var inputDirection = new Vector3(horizontal, 0f, vertical);

        return inputDirection;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(_groundCheck.position, _checkRadius);

        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(_attackCheck.position, _attackRadius);
    }
}

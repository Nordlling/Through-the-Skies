using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _direction;

    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private Animator animator;
    [SerializeField] private Transform model;

    private PlayerFallChecker _playerFallChecker;

    private bool _isGrounded = true;
    private bool _ableToDoubleJump = true;

    private PlayerModel _playerModel;
    
    private readonly int _animationFireballAttackHash = Animator.StringToHash("FireballAttack");
    private readonly int _isGroundedHash = Animator.StringToHash("isGrounded");
    private readonly int _fireballAttackHash = Animator.StringToHash("fireballAttack");
    private readonly int _doubleJumpHash = Animator.StringToHash("doubleJump");
    private readonly int _speedHash = Animator.StringToHash("speed");

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerFallChecker = GetComponent<PlayerFallChecker>();
        animator.SetBool(_isGroundedHash, _isGrounded);
        _playerModel = playerConfig.playerModel;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        _direction.x = horizontalInput * _playerModel.speed;
        _direction.y += _playerModel.gravity * Time.deltaTime;
        
        animator.SetFloat(_speedHash, Mathf.Abs(horizontalInput));
        
        _isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        
        animator.SetBool(_isGroundedHash, _isGrounded);

        if (_isGrounded)
        {
            _direction.y = 0f;
            _ableToDoubleJump = true;
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger(_fireballAttackHash);
            }
            if (Input.GetButtonDown("Jump"))
            {
                _direction.y = _playerModel.jumpForce;
            }
        }
        else
        {
            _direction.y += _playerModel.gravity * Time.deltaTime;
            if (_ableToDoubleJump && Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger(_doubleJumpHash);
                _direction.y = _playerModel.jumpForce;
                _ableToDoubleJump = false;
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == _animationFireballAttackHash)
        {
            return;
        }

        if (horizontalInput != 0)
        {
            model.rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, 0));
        }

        _controller.Move(_direction * Time.deltaTime);
        _playerFallChecker.CheckPlayerToFall(transform.position, _direction);
    }
}
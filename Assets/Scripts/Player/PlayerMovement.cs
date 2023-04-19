using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _direction;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private Animator animator;
    [SerializeField] private Transform model;

    private PlayerFallChecker _playerFallChecker;

    private bool _ableToDoubleJump = true;
    
    private readonly int _animationFireballAttackHash = Animator.StringToHash("FireballAttack");
    private readonly int _isGroundedHash = Animator.StringToHash("isGrounded");
    private readonly int _fireballAttackHash = Animator.StringToHash("fireballAttack");
    private readonly int _doubleJumpHash = Animator.StringToHash("doubleJump");
    private readonly int _speedHash = Animator.StringToHash("speed");

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerFallChecker = GetComponent<PlayerFallChecker>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        _direction.x = horizontalInput * speed;
        _direction.y += gravity * Time.deltaTime;
        
        animator.SetFloat(_speedHash, Mathf.Abs(horizontalInput));
        
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        
        animator.SetBool(_isGroundedHash, isGrounded);

        if (isGrounded)
        {
            _direction.y = 0f;
            _ableToDoubleJump = true;
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger(_fireballAttackHash);
            }
            if (Input.GetButtonDown("Jump"))
            {
                _direction.y = jumpForce;
            }
        }
        else
        {
            _direction.y += gravity * Time.deltaTime;
            if (_ableToDoubleJump && Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger(_doubleJumpHash);
                _direction.y = jumpForce;
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
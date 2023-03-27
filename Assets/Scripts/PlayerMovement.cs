using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 _direction;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private Animator animator;
    [SerializeField] private Transform model;
    

    private bool _ableToDoubleJump = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        _direction.x = horizontalInput * speed;
        _direction.y += gravity * Time.deltaTime;
        
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            _direction.y = -1f;
            _ableToDoubleJump = true;
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
                animator.SetTrigger("doubleJump");
                _direction.y = jumpForce;
                _ableToDoubleJump = false;
            }
        }

        if (horizontalInput != 0)
        {
            model.rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, 0));
        }

        controller.Move(_direction * Time.deltaTime);
    }
}
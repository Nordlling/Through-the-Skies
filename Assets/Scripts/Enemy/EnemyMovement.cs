using System;
using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    [Inject] private GameOverNotifier _gameOverNotifier;
    
    [SerializeField] private Animator animatorController;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToChase = 10f;
    [SerializeField] private float distanceToAttack = 2f;
    [SerializeField] private float speed = 2f;
    
    
    private ActionStateEnum _actionState = ActionStateEnum.Idle;
    private DirectionStateEnum _directionState = DirectionStateEnum.Right;
    private Transform _transform;
    private bool _isChase;
    private bool _isAttack;
    private float _distance;
    
    private readonly int _animationAttackHash = Animator.StringToHash("Attack");
    private readonly int _isAttackHash = Animator.StringToHash("isAttack");
    private readonly int _isChaseHash = Animator.StringToHash("isChase");
    
    private void OnEnable()
    {
        _gameOverNotifier.OnGameOver += GameOver;
    }
    private void OnDisable()
    {
        _gameOverNotifier.OnGameOver -= GameOver;
    }


    private void FixedUpdate()
    {
        if (animatorController.GetCurrentAnimatorStateInfo(0).shortNameHash == _animationAttackHash &&
            animatorController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            return;
        }
        switch (_actionState)
        {
            case ActionStateEnum.Idle:
                Idle();
                break;
            case ActionStateEnum.Walk:
                Chase();
                break;
            case ActionStateEnum.Attack:
                Attack();
                break;
            default:
                Idle();
                break;
        }

        _distance = Vector3.Distance(transform.position, target.position);
        _isAttack = false;
        if (_distance < distanceToChase)
        {
            _actionState = ActionStateEnum.Walk;
            _isChase = true;
            if (_distance < distanceToAttack)
            {
                _actionState = ActionStateEnum.Attack;
                _isAttack = true;
            }
        } else
        {
            _actionState = ActionStateEnum.Idle;
            _isChase = false;
            _isAttack = false;
        }

        animatorController.SetBool(_isChaseHash, _isChase);
        animatorController.SetBool(_isAttackHash, _isAttack);
    }
    
    
    private void Idle()
    {
        animatorController.SetBool(_isChaseHash, false);
        animatorController.SetBool(_isAttackHash, false);
    }

    private void Chase()
    {
        if (target.position.x > transform.position.x)
        {
            _directionState = DirectionStateEnum.Right;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            _directionState = DirectionStateEnum.Left;
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void Attack()
    {
        // Debug.Log("Attack");
    }

    private void GameOver()
    {
        enabled = false;
        _actionState = ActionStateEnum.Idle;
        Idle();
    }
}
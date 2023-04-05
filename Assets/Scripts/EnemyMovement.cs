using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator animatorController;
    private ActionStateEnum _actionState = ActionStateEnum.Idle;
    private DirectionStateEnum _directionState = DirectionStateEnum.Right;
    private Transform _transform;
    private bool _isChase;
    private bool _isAttack;
    private float _distance;

    [SerializeField] private Transform target;
    [SerializeField] private float distanceToChase = 10f;
    [SerializeField] private float distanceToAttack = 2f;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
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

        }

        animatorController.SetBool("isChase", _isChase);
        animatorController.SetBool("isAttack", _isAttack);
    }
    
    
    private void Idle()
    {
        animatorController.SetBool("isChase", _isChase);
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
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }

    public Animator GetAnimatorController()
    {
        return animatorController;
    }
}
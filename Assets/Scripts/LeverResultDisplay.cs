using UnityEngine;

public class LeverResultDisplay : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        Invoke(nameof(test), 6f);
    }

    private void test()
    {
        animator.SetTrigger("fail");
    }
}
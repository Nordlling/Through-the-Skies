using UnityEngine;

public class LeverResultDisplay : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float delay = 2f;
    
    private void OnEnable()
    {
        GameOverNotifier.OnFailDisplay += OnFailDisplay;
    }
    private void OnDisable()
    {
        GameOverNotifier.OnFailDisplay -= OnFailDisplay;
    }

    private void OnFailDisplay()
    {
        Invoke(nameof(FailDisplay), delay);
    }

    private void FailDisplay()
    {
        animator.SetTrigger("fail");
    }
    
}
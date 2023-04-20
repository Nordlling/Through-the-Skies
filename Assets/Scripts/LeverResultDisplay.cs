using UnityEngine;
using Zenject;

public class LeverResultDisplay : MonoBehaviour
{
    [Inject] private GameOverNotifier _gameOverNotifier;
    
    [SerializeField] private Animator animator;
    [SerializeField] private float delay = 2f;
    
    private void OnEnable()
    {
        _gameOverNotifier.OnFailDisplay += OnFailDisplay;
    }
    private void OnDisable()
    {
        _gameOverNotifier.OnFailDisplay -= OnFailDisplay;
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
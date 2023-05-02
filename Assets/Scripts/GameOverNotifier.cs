using UnityEngine;
using UnityEngine.Events;

public class GameOverNotifier : MonoBehaviour
{
    public event UnityAction OnGameOver;
    public event UnityAction OnFailDisplay;

    public void GameOver()
    {
        NotifyEnemiesGameOver();
        NotifyDisplayGameOver();
    }
    
    private void NotifyEnemiesGameOver()
    {
        OnGameOver?.Invoke();
    }
    
    private void NotifyDisplayGameOver()
    {
        OnFailDisplay?.Invoke();
    }
    
    

}

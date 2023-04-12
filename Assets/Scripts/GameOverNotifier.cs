using System;
using System.Collections.Generic;
using UnityEngine;

public class GameOverNotifier : MonoBehaviour
{
    public static event Action OnGameOver;
    public static event Action OnFailDisplay;

    public static void GameOver()
    {
        NotifyEnemiesGameOver();
        NotifyDisplayGameOver();
    }
    
    private static void NotifyEnemiesGameOver()
    {
        OnGameOver?.Invoke();
    }
    
    private static void NotifyDisplayGameOver()
    {
        OnFailDisplay?.Invoke();
    }
    
    

}

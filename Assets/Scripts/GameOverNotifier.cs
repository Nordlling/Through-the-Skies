using System;
using System.Collections.Generic;
using UnityEngine;

public class GameOverNotifier : MonoBehaviour
{
    public static event Action OnGameOver;

    public static void NotifyEnemiesGameOver()
    {
        OnGameOver?.Invoke();
    }

}

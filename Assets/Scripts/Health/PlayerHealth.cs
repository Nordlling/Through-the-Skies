using Zenject;

public class PlayerHealth : AbstractHealth
{
    
    [Inject] private GameOverNotifier _gameOverNotifier;

    protected override void Die()
    {
        base.Die();
        _gameOverNotifier.GameOver();
    }
}
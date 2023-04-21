using Zenject;

public class PlayerHealth : AbstractHealth
{
    
    [Inject] private GameOverNotifier _gameOverNotifier;
    //todo [Inject] private EnemyCollision _enemyCollision;
    
    private void OnEnable()
    {
        EnemyCollision.OnTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        EnemyCollision.OnTakeDamage -= TakeDamage;
    }

    protected override void Die()
    {
        base.Die();
        _gameOverNotifier.GameOver();
    }
}
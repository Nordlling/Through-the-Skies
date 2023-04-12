public class PlayerHealth : AbstractHealth
{
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
        GameOverNotifier.GameOver();
    }
}
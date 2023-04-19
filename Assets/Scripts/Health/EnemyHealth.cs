public class EnemyHealth : AbstractHealth
{
    private void OnEnable()
    {
        FireballCollision.OnTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        FireballCollision.OnTakeDamage -= TakeDamage;
    }
}
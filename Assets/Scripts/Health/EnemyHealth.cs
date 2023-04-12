public class EnemyHealth : AbstractHealth
{

    // private void Start()
    // {
    //     Components = GetComponents<MonoBehaviour>();
    //     Colliders = GetComponentsInChildren<Collider>();
    //     Rigidbody = GetComponent<Rigidbody>();
    // }

    private void OnEnable()
    {
        FireballCollision.OnTakeDamage += TakeDamage;
        EnemyCollision.OnTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        FireballCollision.OnTakeDamage -= TakeDamage;
        EnemyCollision.OnTakeDamage -= TakeDamage;
    }
}
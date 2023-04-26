using UnityEngine;

public class EnemyHealth : AbstractHealth
{
    protected override void Die()
    {
        base.Die();
        Debug.Log("ENEMY IS DIED");
    }
}
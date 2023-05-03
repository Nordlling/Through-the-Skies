using UnityEngine;
using Zenject;

public class EnemyCollision : AbstractDamageCollision
{
    private bool _alreadyDamaged;

    protected override void OnTriggerEnter(Collider other)
    {
        if (!_alreadyDamaged)
        {
            base.OnTriggerEnter(other);
            _alreadyDamaged = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _alreadyDamaged = false;
    }
}

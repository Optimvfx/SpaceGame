using System;
using UnityEngine;

public class Damager<Ignore> : MonoBehaviour
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] private uint _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherISDamagable = collision.gameObject.TryGetComponent(out IDamagable damagable);

        if (otherISDamagable == false)
            return;

        if (new Ignore().Ignore(collision.gameObject) == false)
        {
            damagable.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}

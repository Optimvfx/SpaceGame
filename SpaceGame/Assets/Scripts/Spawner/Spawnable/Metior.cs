using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Metior : Spawnable
{
    [SerializeField] private uint _damage;
    [SerializeField] private uint _maximalHealth;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
         
        _health.Init(_maximalHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            _health.Die();
        }
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage((uint)damage);
    }
}
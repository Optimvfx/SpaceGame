using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Health))]
public class ReadOnlyEnemy : MonoBehaviour, IDamagable
{
    [Range(0, 10000)]
    [SerializeField] private uint _maxHealth;

    [Header("Die")]
    [SerializeField] private UFloat _dieDelay;

    private Health _health;

    public Health Health
    {
        get
        {
            if (_health == null)
                CreateHealth();

            return _health;
        }
    }

    public void TakeDamage(uint damage)
    {
        if (damage < 0)
            throw new ArgumentException();

        Health.TakeDamage(damage);
    }

    private void CreateHealth()
    {
        _health = GetComponent<Health>();
        _health.Init(_maxHealth);
    }
}

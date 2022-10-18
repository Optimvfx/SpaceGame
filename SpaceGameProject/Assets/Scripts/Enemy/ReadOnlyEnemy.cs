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

    private void OnEnable()
    {
        if (_health == null)
            CreateHealth();
    }

    private void OnDisable()
    {
         if (_health == null)
            CreateHealth();
    }

    public void TakeDamage(uint damage)
    {
        if (damage < 0)
            throw new ArgumentException();

        _health.TakeDamage(damage);
    }

    private void CreateHealth()
    {
        _health = GetComponent<Health>();
        _health.Init(_maxHealth);
    }
}

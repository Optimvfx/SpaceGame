using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, IDamagable
{
    [Range(0, 100000)]
    [SerializeField] private uint _maximalHealth;

    private Health _health;

    public float NoramlizdeHealth => (float)_health.Value / _maximalHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction TakingDamage;
    public event UnityAction OnDie;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.Init(_maximalHealth);
    }

    private void OnEnable()
    {
        _health.OnDie += Die;
    }

    private void OnDisable()
    {
        _health.OnDie -= Die;
    }

    public void TakeDamage(uint damage)
    {
        _health.TakeDamage(damage);

        HealthChanged?.Invoke(_health.Value, (int)_maximalHealth);

        TakingDamage?.Invoke();
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
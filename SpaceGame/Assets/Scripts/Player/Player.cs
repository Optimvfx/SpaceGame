using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [Range(0, 1000)]
    [SerializeField] private uint _maximalHealth;

    private Health _health;

    public float NoramlizdeHealth => (float)_health.Value / _maximalHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction TakeDamage;
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

    public void ApplyDamage(uint damage)
    {
        _health.TakeDamage(damage);

        HealthChanged?.Invoke(_health.Value, (int)_maximalHealth);

        TakeDamage?.Invoke();
    }

    public void Die()
    {
        OnDie?.Invoke();
    }
}
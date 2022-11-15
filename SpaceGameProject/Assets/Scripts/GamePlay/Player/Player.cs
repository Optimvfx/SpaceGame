using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerInventory))]
public class Player : MonoBehaviour, IDamagable
{
    [Range(0, 100000)]
    [SerializeField] private uint _maximalHealth;

    private Health _health;

    private PlayerInventory _inventory;

    private uint _deffBuff = 0;

    public float NoramlizdeHealth => (float)_health.Value / _maximalHealth;

    public PlayerInventory Inventory => _inventory;

    private bool _isOnDeff => _deffBuff > 0;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction TakingDamage;
    public event UnityAction OnDie;

    public event UnityAction DeffEnable;
    public event UnityAction DeffDisable;

    private void Awake()
    {
        _inventory = GetComponent<PlayerInventory>();   

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

    private void OnDestroy()
    {
        Die();
    }

    public void AddDeff(uint deffPower)
    {
        if (_isOnDeff == false)
            DeffEnable?.Invoke();

        _deffBuff += deffPower;
    }

    public void TakeDamage(uint damage)
    {
        if (_isOnDeff)
        {
            if (damage >= _deffBuff)
                _deffBuff = 0;
            else
                _deffBuff -= damage;

            if (_isOnDeff == false)
                DeffDisable?.Invoke();

            return;
        }

        _health.TakeDamage(damage);

        HealthChanged?.Invoke(_health.Value, (int)_maximalHealth);

        TakingDamage?.Invoke();
    }

    private void Die()
    {
        OnDie?.Invoke();
    }
}
using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UFloat _dieDellay;

    [SerializeField] private UnityEvent OnDieEvent;

    private int _value;

    private int _maxValue;

    public int Value => _value;
    public int MaxValue => _maxValue;

    private bool _dead;

    public event Action OnDie;
    public event Action Dieing;
    public event Action<int, int> OnValueChanged;

    private void OnDestroy()
    {
        OnDie?.Invoke();
    }

    public void Init(uint maxHealth)
    {
        _maxValue = (int)maxHealth;
        _value = (int)maxHealth;
    }

    public void TakeDamage(uint damage)
    {
        _value -= (int)damage;

        OnValueChanged?.Invoke(_value, _maxValue);

        if (_value <= 0)
            Die();
    }

    public void Die()
    {
        if (_dead)
            return;

        _dead = true;

        Dieing?.Invoke();
        OnDieEvent?.Invoke();

        Destroy(gameObject, _dieDellay);
    }
}

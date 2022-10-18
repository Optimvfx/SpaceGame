using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UFloat _dieDellay;

    [SerializeField] private UnityEvent OnDieEvent;

    private int _value;

    public int Value => _value;

    private bool _dead;

    public event Action OnDie;
    public event Action Dieing;

    private void OnDestroy()
    {
        OnDie?.Invoke();
    }

    public void Init(uint health)
    {
        _value = (int)health;
    }

    public void TakeDamage(uint damage)
    {
        if (damage < 0)
            throw new System.ArgumentException();

        _value -= (int)damage;

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

using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _value;

    public int Value => _value;

    public UnityAction OnDie;
    public UnityEvent OnDieEvent;

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
        OnDie?.Invoke();

        OnDieEvent?.Invoke();

        Destroy(gameObject);
    }
}

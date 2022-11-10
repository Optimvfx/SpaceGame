using UnityEngine;

public class WinPastDie : WinCondition
{
    [SerializeField] private Health _spectable;

    private void OnEnable()
    {
        if(_spectable != null)
            _spectable.OnDie += Win;
    }

    private void OnDisable()
    {
        if (_spectable != null)
            _spectable.OnDie -= Win;
    }

    public void Init(Health health)
    {
        if (health == null)
            throw new System.NullReferenceException();

        _spectable = health;

        _spectable.OnDie += Win;
    }
}

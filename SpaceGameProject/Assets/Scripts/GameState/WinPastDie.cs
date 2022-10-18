using UnityEngine;

public class WinPastDie : WinCondition
{
    [SerializeField] private Health _spectable;

    private void OnEnable()
    {
        _spectable.OnDie += Win;
    }

    private void OnDisable()
    {
        _spectable.OnDie -= Win;
    }
}

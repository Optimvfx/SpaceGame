using UnityEngine;

public class LossByDie : LosseCondition
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.OnDie += Losse;
    }

    private void OnDisable()
    {
        _player.OnDie -= Losse;
    }
}

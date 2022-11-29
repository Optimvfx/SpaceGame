using UnityEngine;

public class EnterBossStateOnSpawnBoss : MonoBehaviour
{
    [SerializeField] private TransiterToBossPastTime _spawner;
    [SerializeField] private GameModeState _modeState;

    private void OnEnable()
    {
        _spawner.OnSpawn += (boss) => EnterBossState();
    }

    private void OnDisable()
    {
        _spawner.OnSpawn -= (boss) => EnterBossState();
    }

    private void EnterBossState()
    {
        _modeState.TrySetCurrentState(GameModeState.CurrentState.BossFight);
    }
}

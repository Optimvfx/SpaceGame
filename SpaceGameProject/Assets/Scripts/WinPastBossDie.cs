using UnityEngine;

public class WinPastBossDie : MonoBehaviour
{
    [SerializeField] private GoToBossPastTime _spawner;
    [SerializeField] private WinPastDie _winPastDie;

    private void OnEnable()
    {
        _spawner.OnSpawn += InitWinPastDie;
    }

    private void OnDisable()
    {
        _spawner.OnSpawn -= InitWinPastDie;
    }

    private void InitWinPastDie(BossEnemy enemy)
    {
        _winPastDie.Init(enemy.Health);
    }
}

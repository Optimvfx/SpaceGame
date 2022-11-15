using UnityEngine;

public class InitEnemySpawnerByBossArguments : MonoBehaviour
{
    [SerializeField] private BossEnemySpawner _enemySpawner;
    [SerializeField] private EnemySpawnByTime _spawnByTime;
    [SerializeField] private BossEnemy _enemy;

    private void OnEnable()
    {
        _enemy.OnActivate += InitSpawner;
    }

    private void OnDisable()
    {
        _enemy.OnActivate -= InitSpawner;
    }

    private void InitSpawner(BossEnemyInitArguments arguments)
    {
        _enemySpawner.InitArguments(arguments);
        _spawnByTime.StartSpawn();
    }
}

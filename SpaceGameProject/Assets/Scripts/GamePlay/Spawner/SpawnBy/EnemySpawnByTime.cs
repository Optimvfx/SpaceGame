using UnityEngine;

[RequireComponent(typeof(BossEnemySpawner))]
public class EnemySpawnByTime : SpawnByTime<BossEnemyInitArguments>
{
    [SerializeField] private UFloat _dellay;

    public void StartSpawn(UFloat? timeBetweenSpawn = null)
    {
        if (timeBetweenSpawn != null)
            _dellay = timeBetweenSpawn.Value;

        Init(GetComponent<BossEnemySpawner>());

        StartCoroutine(StartSpawning(_dellay));
    }
}

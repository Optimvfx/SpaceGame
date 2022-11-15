using UnityEngine;

public class SpawerEnemyOnePointSellector : SpawnerSpawnPositionSellector<BossEnemyInitArguments>
{
    [SerializeField] private Transform _spawnPoint;

    public override Vector3 GetNextSpawnPosition(BossEnemyInitArguments spawnArguments)
    {
        return _spawnPoint.position;
    }
}

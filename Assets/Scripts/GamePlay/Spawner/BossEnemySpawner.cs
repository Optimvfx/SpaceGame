using UnityEngine;

[RequireComponent(typeof(SpawnerNextSpawnableSellector<BossEnemyInitArguments>))]
[RequireComponent(typeof(SpawnerSpawnPositionSellector<BossEnemyInitArguments>))]
public class BossEnemySpawner : SpawnerBase<BossEnemyInitArguments>
{
    private BossEnemyInitArguments _initArguments;

    private void Awake()
    {
        var nextSpawnableSellector = GetComponent<SpawnerNextSpawnableSellector<BossEnemyInitArguments>>();
        var spawnPositionSellector = GetComponent<SpawnerSpawnPositionSellector<BossEnemyInitArguments>>();

        Init(nextSpawnableSellector, spawnPositionSellector);
    }

    public void InitArguments(BossEnemyInitArguments arguments)
    {
        if (arguments == null)
            throw new System.NullReferenceException();

        _initArguments = arguments;
    }

    protected override BossEnemyInitArguments GetNextSpawnArguments()
    {
        if (_initArguments == null)
            throw new System.NullReferenceException();

        return _initArguments;
    }
}

using UnityEngine;

[RequireComponent(typeof(SpawnerNextSpawnableSellector<MeteorSpawner.MeteorSpawnerArguments>))]
[RequireComponent(typeof(SpawnerSpawnPositionSellector<MeteorSpawner.MeteorSpawnerArguments>))]
public class MeteorSpawner : Spawner<MeteorSpawner.MeteorSpawnerArguments>
{
    private void Awake()
    {
        var nextSpawnableSellector = GetComponent<SpawnerNextSpawnableSellector<MeteorSpawner.MeteorSpawnerArguments>>();
        var spawnPositionSellector = GetComponent<SpawnerSpawnPositionSellector<MeteorSpawner.MeteorSpawnerArguments>>();

        Init(nextSpawnableSellector, spawnPositionSellector);
    }

    protected override MeteorSpawnerArguments GetNextSpawnArguments()
    {
        return new MeteorSpawnerArguments();
    }


    public class MeteorSpawnerArguments : ISpawnArguments
    {

    }
}

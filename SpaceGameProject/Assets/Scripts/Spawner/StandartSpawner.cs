using UnityEngine;

[RequireComponent(typeof(SpawnerNextSpawnableSellector<Metior, StandartSpawner.StandartSpawnerArguments>))]
[RequireComponent(typeof(SpawnerSpawnPositionSellector<StandartSpawner.StandartSpawnerArguments>))]
public class StandartSpawner : Spawner<Metior, StandartSpawner.StandartSpawnerArguments>
{
    private void Awake()
    {
        var nextSpawnableSellector = GetComponent<SpawnerNextSpawnableSellector<Metior, StandartSpawner.StandartSpawnerArguments>>();
        var spawnPositionSellector = GetComponent<SpawnerSpawnPositionSellector<StandartSpawner.StandartSpawnerArguments>>();

        Init(nextSpawnableSellector, spawnPositionSellector);
    }

    protected override StandartSpawnerArguments GetNextSpawnArguments()
    {
        return new StandartSpawnerArguments();
    }


    public class StandartSpawnerArguments : ISpawnArguments
    {

    }
}

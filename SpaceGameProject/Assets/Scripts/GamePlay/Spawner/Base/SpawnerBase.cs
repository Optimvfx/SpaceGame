using System;
using UnityEngine;

public abstract class SpawnerBase<Arguments> : MonoBehaviour
    where Arguments : ISpawnArguments
{
    [SerializeField] private Transform _container;

    private SpawnerNextSpawnableSellector<Arguments> _nextSpawnableSellector;
    private SpawnerSpawnPositionSellector<Arguments> _spawnerSpawnPositionSellector;

    public void Init(SpawnerNextSpawnableSellector<Arguments> nextSpawnableSellector, SpawnerSpawnPositionSellector<Arguments> spawnerSpawnPositionSellector, Transform container = null)
    {
        if (container != null)
            _container = container;

        _nextSpawnableSellector = nextSpawnableSellector;
        _spawnerSpawnPositionSellector = spawnerSpawnPositionSellector;
    }

    public void TrySpawn()
    {
        if (_nextSpawnableSellector == null || _spawnerSpawnPositionSellector == null)
            throw new NullReferenceException();

        var nextArguments = GetNextSpawnArguments();

        var position = _spawnerSpawnPositionSellector.GetNextSpawnPosition(nextArguments);

        var spawnable = _nextSpawnableSellector.GetNextSpawnable(nextArguments, position);

        spawnable.transform.position = position;

        if (_container != null)
            spawnable.transform.parent = _container;
    }

    protected abstract Arguments GetNextSpawnArguments();
}

public interface ISpawnArguments
{

}

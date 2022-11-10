using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Extensions;

public class SpawnerRandomPointSellector : SpawnerSpawnPositionSellector<MeteorSpawner.MeteorSpawnerArguments>
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    
    private SpawnPoint _previous;

    private void Reset()
    {
        _spawnPoints = transform.GetComponentsInChildren<SpawnPoint>().ToList();
    }

    public override Vector3 GetNextSpawnPosition(MeteorSpawner.MeteorSpawnerArguments spawnArguments)
    {
        var notEmptySpawnPoints = _spawnPoints.Where(spawnPoint => spawnPoint != null && spawnPoint != _previous).ToList();

        if (notEmptySpawnPoints.Count == 0)
            throw new NullReferenceException();

        _previous = notEmptySpawnPoints.GetRandomElement();

        return _previous.Position;
    }
}

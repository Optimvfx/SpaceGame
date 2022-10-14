using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Extensions;

public class SpawnerRandomPointSellector2D : SpawnerSpawnPositionSellector<StandartSpawner.StandartSpawnerArguments>
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private void Reset()
    {
        _spawnPoints = transform.GetComponentsInChildren<SpawnPoint>().ToList();
    }

    public override Vector3 GetNextSpawnPosition(StandartSpawner.StandartSpawnerArguments spawnArguments)
    {
        if (_spawnPoints.Count == 0)
            throw new NullReferenceException();

        return (Vector2)_spawnPoints.GetRandomElement().transform.position;
    }
}

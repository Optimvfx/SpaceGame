using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

public class SpawnerRandomPrefabSellector : SpawnerNextSpawnableSellector<Metior, StandartSpawner.StandartSpawnerArguments>
{
    [SerializeField] private List<Metior> _prefabs;

    public override Metior GetNextSpawnablePrefab(StandartSpawner.StandartSpawnerArguments spawnArguments)
    {
        var notEmptyPrefabs = _prefabs.Where(spawnPoint => spawnPoint != null).ToList();

        if (notEmptyPrefabs.Count == 0)
            throw new NullReferenceException();

        return notEmptyPrefabs.GetRandomElement();
    }
}

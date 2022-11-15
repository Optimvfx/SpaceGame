using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

public class SpawnerRandomObjectSellector <Prefab, Arguments> : SpawnerNextSpawnableSellector<Arguments>
    where Prefab : MonoBehaviour
    where Arguments : ISpawnArguments
{
    [SerializeField] private List<Prefab> _prefabs;

    public override GameObject GetNextSpawnable(Arguments spawnArguments, Vector3 position)
    {
        var notEmptyPrefabs = _prefabs.Where(spawnPoint => spawnPoint != null).ToList();

        if (notEmptyPrefabs.Count == 0)
            throw new NullReferenceException();

        var newObject = Instantiate(notEmptyPrefabs.GetRandomElement(), position, Quaternion.identity);

        Init(newObject, spawnArguments);

        return newObject.gameObject;
    }

    protected virtual void Init(Prefab intible, Arguments spawnArguments)
    {

    }
}

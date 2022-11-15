using UnityEngine;
using System;
using System.Collections;

public class SpawnByTime<Arguments> : MonoBehaviour
    where Arguments : ISpawnArguments
{
    private SpawnerBase<Arguments> _spawner;

    public void Init(SpawnerBase<Arguments> spawner)
    {
        _spawner = spawner;
    }

    protected IEnumerator StartSpawning(float secondsBreakBetweenSpawning)
    {
        if (_spawner == null)
            throw new NullReferenceException();

        if (secondsBreakBetweenSpawning <= 0)
            throw new ArgumentException();

        while(true)
        {
            try
            {
                _spawner.TrySpawn();
            }
            catch
            { 
            }

            yield return new WaitForSeconds(secondsBreakBetweenSpawning);
        }
    }
}


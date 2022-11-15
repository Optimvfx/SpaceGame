using UnityEngine;

[RequireComponent(typeof(MeteorSpawner))]
public class MetorSpawnByTime : SpawnByTime<MeteorSpawner.MeteorSpawnerArguments>
{
    [SerializeField] private UFloat _dellay;

    public void StartSpawn(UFloat timeBetweenSpawn)
    {
        _dellay = timeBetweenSpawn;

        Init(GetComponent<MeteorSpawner>());

        StartCoroutine(StartSpawning(_dellay));
    }
}

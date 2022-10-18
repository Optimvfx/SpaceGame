using UnityEngine;

[RequireComponent(typeof(StandartSpawner))]
public class StandartSpawnByTime : SpawnByTime<Metior, StandartSpawner.StandartSpawnerArguments>
{
    [SerializeField] private UFloat _dellay;

    public void StartSpawn(UFloat? timeBetweenSpawn = null)
    {
        if (timeBetweenSpawn != null)
            _dellay = timeBetweenSpawn.Value;

        Init(GetComponent<StandartSpawner>());

        StartCoroutine(StartSpawning(_dellay));
    }
}

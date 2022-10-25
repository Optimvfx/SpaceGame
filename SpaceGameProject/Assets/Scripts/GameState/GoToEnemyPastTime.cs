using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GoToEnemyPastTime : MonoBehaviour
{
    [SerializeField] private ReadOnlyEnemy _spawanble;
    [SerializeField] private StandartSpawner _spawner;
    [SerializeField] private UFloat _waitTimeInSecond;

    [SerializeField] private UnityEvent _onSpawn;

    public event Action<ReadOnlyEnemy> OnSpawn;

    private void Start()
    {
        StartCoroutine(SpawnBossPastTime());
    }

    private IEnumerator SpawnBossPastTime()
    {
        yield return new WaitForSeconds(_waitTimeInSecond);

        _onSpawn?.Invoke();
        OnSpawn?.Invoke(_spawanble);

        _spawner.gameObject.SetActive(false);
        _spawanble.gameObject.SetActive(true);
    }

    public void Init(ReadOnlyEnemy bossEnemy)
    {
        if (bossEnemy == null)
            throw new System.NullReferenceException();

        _spawanble = bossEnemy;
    }
}

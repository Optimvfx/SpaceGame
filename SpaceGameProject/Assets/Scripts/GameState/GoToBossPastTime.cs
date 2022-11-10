using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GoToBossPastTime : MonoBehaviour
{
    [SerializeField] private BossEnemy _enemyPrefab;
    [SerializeField] private MeteorSpawner _meteorSpawner;

    [SerializeField] private Vector2 _spawnPoint;

    [SerializeField] private UFloat _waitTimeInSecond;

    [SerializeField] private UnityEvent<BossEnemy> _onSpawn;

    public event Action<BossEnemy> OnSpawn;

    [Header("Init")]
    [SerializeField] private Player _target;
    [SerializeField] private Transform _bulletContainer;

    private void Start()
    {
        StartCoroutine(SpawnBossPastTime());
    }

    private IEnumerator SpawnBossPastTime()
    {
        yield return new WaitForSeconds(_waitTimeInSecond);

        SpawnBoss();
    }

    private void SpawnBoss()
    {
        var enemy = Instantiate(_enemyPrefab, _spawnPoint, Quaternion.identity);

        enemy.Init(new BossEnemyInitArguments(_target, _bulletContainer));

        enemy.name = _enemyPrefab.name;

        _onSpawn?.Invoke(enemy);
        OnSpawn?.Invoke(enemy);

        _meteorSpawner.gameObject.SetActive(false);
    }

    public void Init(BossEnemy bossEnemy)
    {
        if (bossEnemy == null)
            throw new System.NullReferenceException();

        _enemyPrefab = bossEnemy;
    }
}

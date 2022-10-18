using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GoToBossPastTime : MonoBehaviour
{
    [SerializeField] private BossEnemy _target;
    [SerializeField] private StandartSpawner _spawner;
    [SerializeField] private UFloat _waitTimeInSecond;

    [SerializeField] private UnityEvent _onSpawn;

    private void Start()
    {
        StartCoroutine(SpawnBossPastTime());
    }

    private IEnumerator SpawnBossPastTime()
    {
        yield return new WaitForSeconds(_waitTimeInSecond);

        _onSpawn?.Invoke();

        _spawner.gameObject.SetActive(false);
        _target.gameObject.SetActive(true);
    }
}

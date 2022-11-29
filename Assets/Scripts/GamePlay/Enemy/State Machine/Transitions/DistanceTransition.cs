using UnityEngine;

[RequireComponent(typeof(BossEnemy))]
public class DistanceTransition : Transition
{
    [SerializeField] private UFloat _transitionRange;
    [SerializeField] private UFloat _rangetSpread;

    private BossEnemy _standartEnemy;

    public override bool NeedTransit => _standartEnemy.Target == null || Vector2.Distance(transform.position, _standartEnemy.Target.transform.position) < _transitionRange;

    private void Awake()
    {
        _standartEnemy = GetComponent<BossEnemy>();
        _transitionRange += Random.Range(-_rangetSpread, _rangetSpread);
    }
}
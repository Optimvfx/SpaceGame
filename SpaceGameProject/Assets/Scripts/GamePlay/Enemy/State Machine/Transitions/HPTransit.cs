using UnityEngine;

[RequireComponent(typeof(BossEnemy))]
public class HPTransit : Transition
{
    private const float _maxProcent = 100;

    [Range(0, _maxProcent)]
    [SerializeField] private float _hpProcentToTransit;

    private BossEnemy _bossEnemy;

    public override bool NeedTransit => _bossEnemy.Health.Value < (_bossEnemy.Health.MaxValue / _maxProcent) * _hpProcentToTransit;

    private void Awake()
    {
        _bossEnemy = GetComponent<BossEnemy>();
    }
}

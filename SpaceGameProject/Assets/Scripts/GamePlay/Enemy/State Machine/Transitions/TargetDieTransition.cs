using UnityEngine;

[RequireComponent(typeof(BossEnemy))]
public class TargetDieTransition : Transition
{
    private BossEnemy _standartEnemy;

    private void Awake()
    {
        _standartEnemy = GetComponent<BossEnemy>();
    }

    public override bool NeedTransit => _standartEnemy.Target == null;
}
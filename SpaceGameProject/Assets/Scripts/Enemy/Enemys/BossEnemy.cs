using System.Linq;
using UnityEngine;

public class BossEnemy : Enemy<StandartEnemyInitArguments>
{
    [SerializeField] private Turret[] _turrets;

    [SerializeField] private Player _target;

    public Player Target => _target;

    private void Awake()
    {
        StopTurrets();
    }

    public void ActivateTurrets()
    {
        foreach (var turret in _turrets.Where(turret => turret != null))
            turret.enabled = true;
    }

    public void StopTurrets()
    {
        foreach (var turret in _turrets.Where(turret => turret != null))
            turret.enabled = false;
    }

    public override void Init(StandartEnemyInitArguments initArguments)
    {
        _target = initArguments.Player;
    }
}

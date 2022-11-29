using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BossEnemy : Enemy<BossEnemyInitArguments>
{
    [SerializeField] private BossWeapon[] _weapons;

    [SerializeField] private Player _target;

    private BossEnemyInitArguments _initArguments;

    public Player Target => _target;

    public event UnityAction<BossEnemyInitArguments> OnActivate;

    private void Awake()
    {
        DiActivateWeapons();
    }

    public void ActivateWeapons()
    {
        if (_initArguments == null)
            throw new System.NullReferenceException();

        foreach (var turret in _weapons.Where(weapon => weapon != null))
            turret.Activate(_initArguments);

        OnActivate?.Invoke(_initArguments);
    }

    public void DiActivateWeapons()
    {
        foreach (var turret in _weapons.Where(weapon => weapon != null))
            turret.DiActivate();
    }

    public override void Init(BossEnemyInitArguments initArguments)
    {
        _target = initArguments.Player;
        _initArguments = initArguments;
    }
}

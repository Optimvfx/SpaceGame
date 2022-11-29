using UnityEngine;

[RequireComponent(typeof(BossEnemy))]
public class ActivateTurretsState : SinglDo
{
    private BossEnemy _self;

    private void Awake()
    {
        _self = GetComponent<BossEnemy>();
    }

    private void OnEnable()
    {
        _self.ActivateWeapons();

        EndDo();
    }
}

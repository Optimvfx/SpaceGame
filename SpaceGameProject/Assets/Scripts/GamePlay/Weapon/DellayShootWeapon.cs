using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DellayShootWeapon<Ignore> : Weapon<Ignore>
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] private UFloat _rechargeTimeInSeconds;

    private Coroutine _rechargeCorutine;

    private bool _canShot = true;

    public override bool CanShoot()
    {
        if (_canShot == false)
            return false;

        if (_rechargeCorutine != null)
            StopCoroutine(_rechargeCorutine);

        _rechargeCorutine = StartCoroutine(ReCharge());

        return true;
    }

    private System.Collections.IEnumerator ReCharge()
    {
        _canShot = false;

        yield return new WaitForSeconds(_rechargeTimeInSeconds);

        _canShot = true;
    }
}

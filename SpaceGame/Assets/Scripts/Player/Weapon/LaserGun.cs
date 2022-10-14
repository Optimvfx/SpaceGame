using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private UFloat _rechargeTimeInSeconds;
    [SerializeField] private ShotPoint _shootPoint;

    private Coroutine _rechargeCorutine;

    private bool _canShot = true;

    public override bool CanShoot()
    {
        if(_canShot)
        {
            if (_rechargeCorutine != null)
                StopCoroutine(_rechargeCorutine);

            _rechargeCorutine = StartCoroutine(ReCharge());

            return true;
        }

        return false;
    }

    public override IEnumerable<Bullet> Shoot()
    {
        var bullet = Instantiate(Bullet, _shootPoint.transform.position, Quaternion.identity);

        return new[] { bullet };
    }

    public System.Collections.IEnumerator ReCharge()
    {
        _canShot = false;

        yield return new WaitForSeconds(_rechargeTimeInSeconds);

        _canShot = true;
    }
}
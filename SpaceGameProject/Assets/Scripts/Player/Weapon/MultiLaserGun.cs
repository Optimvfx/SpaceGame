using System.Collections.Generic;
using UnityEngine;

public class MultiLaserGun : Weapon
{
    [SerializeField] private UFloat _rechargeTimeInSeconds;
    [SerializeField] private ShotPoint[] _shootPoints;

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
       var bullets = new List<Bullet>();

        foreach(var shootPoint in _shootPoints)
        {
            var bullet = Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);

            bullets.Add(bullet);
        }

        return bullets;
    }

    public System.Collections.IEnumerator ReCharge()
    {
        _canShot = false;

        yield return new WaitForSeconds(_rechargeTimeInSeconds);

        _canShot = true;
    }
}
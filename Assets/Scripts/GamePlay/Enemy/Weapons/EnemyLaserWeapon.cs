using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserWeapon : Weapon<EnemyBullet.EnemyBulletIgnore>
{
    [SerializeField] private UFloat _rechargeTimeInSeconds;
    [SerializeField] private ShootPoint _shootPoint;

    private Coroutine _rechargeCorutine;

    private bool _canShot = true;

    public override bool CanShoot()
    {
        if (_canShot)
        {
            if (_rechargeCorutine != null)
                StopCoroutine(_rechargeCorutine);

            _rechargeCorutine = StartCoroutine(ReCharge());

            return true;
        }

        return false;
    }

    protected override IEnumerable<Bullet<EnemyBullet.EnemyBulletIgnore>> Shoot()
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

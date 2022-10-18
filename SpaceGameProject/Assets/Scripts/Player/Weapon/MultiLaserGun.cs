using System.Collections.Generic;
using UnityEngine;

public class MultiLaserGun : Weapon<PlayerBullet.PlayerBulletIgnore>
{
    [SerializeField] private UFloat _rechargeTimeInSeconds;
    [SerializeField] private ShotPoint[] _shootPoints;

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

    public System.Collections.IEnumerator ReCharge()
    {
        _canShot = false;

        yield return new WaitForSeconds(_rechargeTimeInSeconds);

        _canShot = true;
    }

    public override IEnumerable<Bullet<PlayerBullet.PlayerBulletIgnore>> Shoot()
    {
        var bullets = new List<Bullet<PlayerBullet.PlayerBulletIgnore>>();

        foreach (var shootPoint in _shootPoints)
        {
            var bullet = Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity) as Bullet<PlayerBullet.PlayerBulletIgnore>;

            bullets.Add(bullet);
        }

        return bullets;
    }
}
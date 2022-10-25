using System.Collections.Generic;
using UnityEngine;

public class RaylGun : DellayShootWeapon<PlayerBullet.PlayerBulletIgnore>
{
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private UFloat _shootAngle;
    [SerializeField] private uint _shootCount;

    public override IEnumerable<Bullet<PlayerBullet.PlayerBulletIgnore>> Shoot()
    {
        var bullets = new List<Bullet<PlayerBullet.PlayerBulletIgnore>>();

        var stepAngle = _shootAngle / _shootCount;
        var startAngle = -stepAngle * (_shootCount / 2);

        for (int i = 0; i < _shootCount; i++)
        {
            var bullet = Instantiate(Bullet, _shootPoint.transform.position, Quaternion.Euler(new Vector3(0,0, startAngle + (stepAngle * i)))) as Bullet<PlayerBullet.PlayerBulletIgnore>;

            bullets.Add(bullet);
        }

        return bullets;
    }
}


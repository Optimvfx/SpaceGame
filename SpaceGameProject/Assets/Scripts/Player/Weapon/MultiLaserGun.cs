using System.Collections.Generic;
using UnityEngine;

public class MultiLaserGun : DellayShootWeapon<PlayerBullet.PlayerBulletIgnore>
{
    [SerializeField] private ShootPoint[] _shootPoints;

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
using System.Collections.Generic;
using UnityEngine;

public class LaserMega : Weapon<PlayerBullet.PlayerBulletIgnore>
{
    [SerializeField] private ShootPoint _shootPoint;

    private Bullet<PlayerBullet.PlayerBulletIgnore> _laser;

    private void OnDisable()
    {
        if (_laser != null)
            Destroy(_laser.gameObject);
    }

    public override bool CanShoot()
    {
        return true;
    }

    public override IEnumerable<Bullet<PlayerBullet.PlayerBulletIgnore>> Shoot()
    {
        if (_laser != null)
            Destroy(_laser.gameObject);

        _laser = Instantiate(Bullet, _shootPoint.transform.position, Quaternion.identity);

        return new[] { _laser };
    }
}

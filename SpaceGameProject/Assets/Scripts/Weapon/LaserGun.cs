using System.Collections.Generic;
using UnityEngine;

public class LaserGun<Ignore> : DellayShootWeapon<Ignore>
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] private ShootPoint _shootPoint;

    public override IEnumerable<Bullet<Ignore>> Shoot()
    {
        var bullet = Instantiate(Bullet, _shootPoint.transform.position, Quaternion.identity);

        return new[] { bullet };
    }
}
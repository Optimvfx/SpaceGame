using System.Collections.Generic;
using UnityEngine;

public class RaylGun<Ignor> : DellayShootWeapon<Ignor>
    where Ignor : IDamageIgnore, new()
{
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private UFloat _shootAngle;
    [SerializeField] private uint _shootCount;

    protected override IEnumerable<Bullet<Ignor>> Shoot()
    {
        var bullets = new List<Bullet<Ignor>>();

        var stepAngle = _shootAngle / _shootCount;
        var startAngle = -stepAngle * (_shootCount / 2);

        for (int i = 0; i < _shootCount; i++)
        {
            var bullet = Instantiate(Bullet, _shootPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, startAngle + (stepAngle * i))));

            bullets.Add(bullet);
        }

        return bullets;
    }
}


using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserWeapon : Weapon<EnemyBullet.EnemyBulletIgnore>
{
    [SerializeField] private UFloat _rechargeTimeInSeconds;
    [SerializeField] private ShootPoint _shootPoint;
    [SerializeField] private float _extraAngle;
    [SerializeField] private Transform _rotationExemple;

    private Player _target;

    private Coroutine _rechargeCorutine;

    private bool _canShot = true;

    public void Init(Player player)
    {
        _target = player;
    }

    public override bool CanShoot()
    {
        if (_target == null)
            return false;

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

        bullet.transform.rotation = Quaternion.Euler(_rotationExemple.rotation.eulerAngles + LookAt2d.AngeleToQuaternion(_extraAngle).eulerAngles);

        return new[] { bullet };
    }

    public System.Collections.IEnumerator ReCharge()
    {
        _canShot = false;

        yield return new WaitForSeconds(_rechargeTimeInSeconds);

        _canShot = true;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class P32ShootGun : Weapon<PlayerBullet.PlayerBulletIgnore>
{
    [SerializeField] private UFloat _rechargeTimeInSeconds;
    [SerializeField] private UFloat _shotTimeInSeconds;
    [SerializeField] private uint _shootToRecharge;

    [SerializeField] private ShootPoint _shootPoint;

    private uint _shootCount;

    private Coroutine _rechargeCorutine;

    private bool _canShoot = true;

    public override bool CanShoot()
    {
        if (_canShoot)
        {
            if (_rechargeCorutine != null)
                StopCoroutine(_rechargeCorutine);

            _shootCount++;

            if (_shootCount >= _shootToRecharge)
            {
                _rechargeCorutine = StartCoroutine(WaitTimeToShoot(_rechargeTimeInSeconds));
                _shootCount = 0;
            }
            else
            {
                _rechargeCorutine = StartCoroutine(WaitTimeToShoot(_shotTimeInSeconds));
            }

            return true;
        }

        return false;
    }

    protected override IEnumerable<Bullet<PlayerBullet.PlayerBulletIgnore>> Shoot()
    {
        return new[] { Instantiate(Bullet, _shootPoint.transform.position, Quaternion.identity)}; 
    }

    private System.Collections.IEnumerator WaitTimeToShoot(UFloat waitingTime)
    {
        _canShoot = false;

        yield return new WaitForSeconds(waitingTime);

        _canShoot = true;
    }
}

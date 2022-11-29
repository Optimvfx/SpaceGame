using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Shoter<Ignore> : MonoBehaviour
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] protected Transform BulletContainer;

    public event UnityAction OnShot;

    public void TryShoot()
    {
        TryShoot(out IEnumerable<Bullet<Ignore>> bullets);
    }

    public void TryShoot(out IEnumerable<Bullet<Ignore>> bullets)
    {
        bullets = new Bullet<Ignore>[0];

        if (TimeExtenstions.IsTimeStoped())
            return;

        var currentWeapon = GetCurrentWeapon();

        if (currentWeapon.TryShoot(out bullets) == false)
            return;

        OnShot?.Invoke();

        foreach (var newBullet in bullets)
        {
            newBullet.transform.parent = BulletContainer;
        }
    }

    protected abstract Weapon<Ignore> GetCurrentWeapon();
}
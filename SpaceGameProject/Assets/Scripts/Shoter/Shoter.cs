using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Shoter<Ignore> : MonoBehaviour
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] private Transform _bulletContainer;

    public event UnityAction OnShot;

    public void TryShoot()
    {
        if (TimeExtenstions.IsTimeStoped())
            return;

        var currentWeapon = GetCurrentWeapon();

        if (currentWeapon.TryShoot(out IEnumerable<Bullet<Ignore>> newBullets) == false)
            return;

        OnShot?.Invoke();

        foreach (var newBullet in newBullets)
        {
            newBullet.transform.parent = _bulletContainer;
        }
    }

    protected abstract Weapon<Ignore> GetCurrentWeapon();
}

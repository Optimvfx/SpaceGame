using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerShoter : MonoBehaviour
{
    private readonly uint MaximalBulitCount = 100;

    [SerializeField] private Transform _bulletContainer;
    
    private PlayerInventory _inventory;

    private LinkedList<Bullet> _bullets;

    public event UnityAction OnShot;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventory>();

        _bullets = new LinkedList<Bullet>();
    }

    public void TryShoot()
    {
        if (TimeExtenstions.IsTimeStoped())
            return;

        if (_inventory.CurrentWeapon.CanShoot() == false)
            return;

        OnShot?.Invoke();

        var newBullets = _inventory.CurrentWeapon.Shoot();

        foreach (var newBullet in newBullets)
        {
            newBullet.transform.parent = _bulletContainer;
            newBullet.OnDestroy += RemoveBullet;
            AddBullet(newBullet);
        }
    }

    private void AddBullet(Bullet newBullet)
    {
        _bullets.AddFirst(newBullet);

        if (_bullets.Count > MaximalBulitCount)
        {
            var removingBullet = _bullets.Last.Value;

            _bullets.RemoveLast();

            Destroy(removingBullet.gameObject);
        }
    }

    private void RemoveBullet(Bullet bullet)
    {
        bullet.OnDestroy -= RemoveBullet;

        _bullets.Remove(bullet);
    }
}

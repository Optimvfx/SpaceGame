using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerShoter : Shoter<PlayerBullet.PlayerBulletIgnore>
{
    private PlayerInventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventory>();
    }
    protected override Weapon<PlayerBullet.PlayerBulletIgnore> GetCurrentWeapon()
    {
        return _inventory.CurrentWeapon;
    }
}

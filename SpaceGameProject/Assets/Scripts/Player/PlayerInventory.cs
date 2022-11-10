using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Transform _weaponContainer;
    [SerializeField] private Weapon<PlayerBullet.PlayerBulletIgnore> _startWeapon;

    private Weapon<PlayerBullet.PlayerBulletIgnore> _currentWeapon;

    private int _currentWeaponNumber = 0;

    public uint Money { get; private set; }
    public Weapon<PlayerBullet.PlayerBulletIgnore> CurrentWeapon => _currentWeapon;

    public event UnityAction<int> MoneyChanged;

    private void Awake()
    {
        TrySellectWeapon(_startWeapon);
    }

    public void AddMoney(uint money)
    {
        Money += money;
        MoneyChanged?.Invoke((int)Money);
    }

    public void TrySellectWeapon(Weapon<PlayerBullet.PlayerBulletIgnore> weapon)
    {
        if (_currentWeapon != null && weapon.Lvl < _currentWeapon.Lvl)
            return;

        if (_currentWeapon != null)
            Destroy(_currentWeapon.gameObject);

        var newWeapon = Instantiate(weapon, _weaponContainer);

        _currentWeapon = newWeapon;
    }
}

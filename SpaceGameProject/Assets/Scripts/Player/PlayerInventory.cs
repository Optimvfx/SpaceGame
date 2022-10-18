using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Transform _weaponContainer;
    [SerializeField] private List<Weapon<PlayerBullet.PlayerBulletIgnore>> _startWeapons;

    private List<Weapon<PlayerBullet.PlayerBulletIgnore>> _weapons;

    private int _currentWeaponNumber = 0;

    public uint Money { get; private set; }
    public Weapon<PlayerBullet.PlayerBulletIgnore> CurrentWeapon => _weapons[_currentWeaponNumber];

    public event UnityAction<int> MoneyChanged;

    private void Awake()
    {
        if (_startWeapons.Count <= 0)
            throw new NullReferenceException("Player did not have any start weapon!");

        CreateWeapons(_startWeapons.Distinct());
    }

    public void AddMoney(uint money)
    {
        Money += money;
        MoneyChanged?.Invoke((int)Money);
    }

    public void SellectNextWeapon()
    {
        ChangeWeapon(1);
    }

    public void SellectPreviousWeapon()
    {
        ChangeWeapon(-1);
    }

    private void ChangeWeapon(int offset)
    {
        _currentWeaponNumber = (_currentWeaponNumber + offset) % _weapons.Count;

        if (_currentWeaponNumber < 0)
            _currentWeaponNumber += _weapons.Count;
    }

    private void CreateWeapons(IEnumerable<Weapon<PlayerBullet.PlayerBulletIgnore>> weapons)
    {
        _weapons = new List<Weapon<PlayerBullet.PlayerBulletIgnore>>();

        foreach (var weapon in weapons)
        {
            AddWeapon(weapon);
        }
    }

    private void AddWeapon(Weapon<PlayerBullet.PlayerBulletIgnore> weapon)
    {
        var newWeapon = Instantiate(weapon, _weaponContainer);

        _weapons.Add(newWeapon);
    }
}

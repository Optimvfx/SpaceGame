using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Transform _weaponContainer;
    [SerializeField] private List<Weapon> _startWeapons;

    private List<Weapon> _weapons;

    private int _currentWeaponNumber = 0;

    public int Money { get; private set; }
    public Weapon CurrentWeapon => _weapons[_currentWeaponNumber];

    public event UnityAction<int> MoneyChanged;

    private void Awake()
    {
        if (_startWeapons.Count <= 0)
            throw new NullReferenceException("Player did not have any start weapon!");

        CreateWeapons(_startWeapons.Distinct());
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
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

    private void CreateWeapons(IEnumerable<Weapon> weapons)
    {
        _weapons = new List<Weapon>();

        foreach (var weapon in weapons)
        {
            AddWeapon(weapon);
        }
    }

    private void AddWeapon(Weapon weapon)
    {
        var newWeapon = Instantiate(weapon, _weaponContainer);

        _weapons.Add(newWeapon);
    }
}

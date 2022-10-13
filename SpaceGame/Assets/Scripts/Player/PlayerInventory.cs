using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    public int Money { get; private set; }

    public event UnityAction<int> MoneyChanged;

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }
}

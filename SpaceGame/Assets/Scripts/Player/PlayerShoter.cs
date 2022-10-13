using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInventory))] 
public class PlayerShoter : MonoBehaviour
{
    private readonly uint MaximalBulitCount = 100;

    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private Transform _shootPoint;

    private PlayerInventory _inventory;

    public event UnityAction OnShot;
}

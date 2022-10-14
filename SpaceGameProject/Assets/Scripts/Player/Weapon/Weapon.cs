using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;

    [SerializeField]  private Bullet _bullet;

    public string Label =>  _label;
    
    protected Bullet Bullet => _bullet;

    public abstract bool CanShoot();

    public abstract IEnumerable<Bullet> Shoot();
}
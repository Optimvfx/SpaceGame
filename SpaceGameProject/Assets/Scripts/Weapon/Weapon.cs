using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon <Ignore> : MonoBehaviour
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] private string _label;

    [SerializeField]  private Bullet<Ignore> _bullet;

    public string Label =>  _label;
    
    protected Bullet<Ignore> Bullet => _bullet;

    public abstract bool CanShoot();

    public abstract IEnumerable<Bullet<Ignore>> Shoot();
}
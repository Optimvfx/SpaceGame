using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon <Ignore> : MonoBehaviour
    where Ignore : IDamageIgnore, new()
{
    [SerializeField] private string _label;
    [SerializeField] private uint _lvl;

    [SerializeField]  private Bullet<Ignore> _bullet;

    public string Label =>  _label;

    public uint Lvl => _lvl;

    protected Bullet<Ignore> Bullet => _bullet;

    public bool TryShoot(out IEnumerable<Bullet<Ignore>> shootedBullets)
    {
        shootedBullets = new Bullet<Ignore>[0];

        if(CanShoot())
        {
            shootedBullets = Shoot();

            return true;
        }

        return false;   
    }

    public abstract bool CanShoot();

    protected abstract IEnumerable<Bullet<Ignore>> Shoot();
}
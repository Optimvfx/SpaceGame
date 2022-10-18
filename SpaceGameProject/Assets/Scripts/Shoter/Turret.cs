using UnityEngine;

[RequireComponent(typeof(Health))]
public class Turret : Shoter<EnemyBullet.EnemyBulletIgnore>, IDamagable
{
    [SerializeField] private uint _maxHealth;
    [SerializeField] private EnemyLaserWeapon _weapon;
    [SerializeField] private Player _target;

    private Health _health;

    private void Update()
    {
        TryShoot();
     
        _weapon.Init(_target);
    }

    protected override Weapon<EnemyBullet.EnemyBulletIgnore> GetCurrentWeapon()
    {
       return _weapon;
    }

    public void TakeDamage(uint damage)
    {
        if (_health == null)
            CreateHealth();

      _health.TakeDamage(damage);
    }

    private void CreateHealth()
    {
        _health = GetComponent<Health>();
        _health.Init(_maxHealth);
    }
}

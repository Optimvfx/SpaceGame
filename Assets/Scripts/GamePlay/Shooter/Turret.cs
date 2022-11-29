using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Turret : Shoter<EnemyBullet.EnemyBulletIgnore>, IDamagable
{
    [Header("HP")]
    [SerializeField] private uint _maxHealth;
    [Header("Shoot")]
    [SerializeField] private Weapon<EnemyBullet.EnemyBulletIgnore> _weapon;
    [Header("Rotate")]
    [Range(-180,180)]
    [SerializeField] private float _extraAngle;
    [SerializeField] private Transform _rotationExemple;

    private Health _health;

    internal void Init(BossEnemyInitArguments arguments)
    {
        BulletContainer = arguments.BulletContainer;
    }

    private void Update()
    {
        TryRotateShoot();
    }

    public void TakeDamage(uint damage)
    {
        if (_health == null)
            CreateHealth();

        _health.TakeDamage(damage);
    }

    private void TryRotateShoot()
    {
        TryShoot(out IEnumerable<Bullet<EnemyBullet.EnemyBulletIgnore>> bullets);

        if (bullets.Count() <= 0)
            return;

        foreach (var bullet in bullets)
        {
            RotateToShootDirection(bullet.transform);
        }
    }

    private void RotateToShootDirection(Transform rotatable)
    {
        rotatable.rotation = Quaternion.Euler(rotatable.rotation.eulerAngles + _rotationExemple.rotation.eulerAngles + LookAt2d.AngeleToQuaternion(_extraAngle).eulerAngles);
    }

    private void CreateHealth()
    {
        _health = GetComponent<Health>();
        _health.Init(_maxHealth);
    }

    protected override Weapon<EnemyBullet.EnemyBulletIgnore> GetCurrentWeapon()
    {
        return _weapon;
    }
}

using UnityEngine;
using System;

public class BossEnemyInitArguments : IEnemyInitArguments, ISpawnArguments
{
    private Player _player;
    private Transform _bulletContainer;

    public Player Player => _player;
    public Transform BulletContainer => _bulletContainer;

    public BossEnemyInitArguments(Player player, Transform bulletContainer)
    {
        if (player == null || bulletContainer == null)
            throw new ArgumentException();

        _player = player;
        _bulletContainer = bulletContainer;
    }
}

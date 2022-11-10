using UnityEngine;

public class BuffNewWeapon : Buffer
{
    [SerializeField] private Weapon<PlayerBullet.PlayerBulletIgnore> _weapon;

    public override void Buff(Player player)
    {
        player.Inventory.TrySellectWeapon(_weapon);
    }
}

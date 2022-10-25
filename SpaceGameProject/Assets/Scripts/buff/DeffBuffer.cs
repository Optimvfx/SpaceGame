using UnityEngine;

public class DeffBuffer : Buffer
{
    [SerializeField] private uint _buffPower;

    public override void Buff(Player player)
    {
        player.AddDeff(_buffPower);
    }
}

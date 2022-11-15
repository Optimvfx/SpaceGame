using UnityEngine;

public class SpawnerRandomEnemySellector : SpawnerRandomObjectSellector<BossEnemy, BossEnemyInitArguments>
{
    protected override void Init(BossEnemy intible, BossEnemyInitArguments spawnArguments)
    {
        intible.Init(spawnArguments);
    }
}

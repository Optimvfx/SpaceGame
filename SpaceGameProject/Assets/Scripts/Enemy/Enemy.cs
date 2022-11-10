public abstract class Enemy <InitArguments> : ReadOnlyEnemy
        where InitArguments : IEnemyInitArguments
{
    public abstract void Init(InitArguments initArguments);
}

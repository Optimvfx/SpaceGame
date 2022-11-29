using System.Threading.Tasks;

public interface ISpaceGameApi
{
    void LevelUp();

    void Authorise(string apiKey);

    Task<TopMenu.PlayerTop> GetTop();

    Task<uint> GetMoney();

    void SetVirtualScore(uint score);
}

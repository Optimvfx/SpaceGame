using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public interface ISpaceGameApi
{
    void LevelUp();

    Task<TopMenu.PlayerTop> GetTop();

    Task<uint> GetMoney();
}

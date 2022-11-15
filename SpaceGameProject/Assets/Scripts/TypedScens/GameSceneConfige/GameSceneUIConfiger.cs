using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIConfiger : GameSceneLoadEvent
{
    [SerializeField] private TopMenu _topMenu;
    [SerializeField] private PlayerInventory _playerInventory;

    public override void OnSceneLoaded(GameSceneArguments argument)
    {
        InitUI(argument);
    }

    private void InitUI(GameSceneArguments argument)
    {
        _topMenu.Init(argument.PlayerTop);
        _playerInventory.AddMoney(argument.HardnesLevel);
    }
}

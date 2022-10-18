using UnityEngine;

public class GameSceneArguments
{
    public uint HardnesLevel { get; private set; }

    public TopMenu.PlayerTop PlayerTop { get; private set; }

    public GameSceneArguments(uint hardnesLevel, TopMenu.PlayerTop playerTop)
    {
        HardnesLevel = hardnesLevel;
        PlayerTop = playerTop;
    }
}

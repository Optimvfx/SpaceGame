using UnityEngine;

public class GameSceneArguments
{
    public uint HardnesLevel { get; private set; }

    public TopMenu.PlayerTop PlayerTop { get; private set; }

    public bool DeviceIsMobile { get; private set; }

    public GameSceneArguments(uint hardnesLevel, TopMenu.PlayerTop playerTop, bool deviceIsMobile)
    {
        HardnesLevel = hardnesLevel;
        PlayerTop = playerTop;
        DeviceIsMobile = deviceIsMobile;
    }
}

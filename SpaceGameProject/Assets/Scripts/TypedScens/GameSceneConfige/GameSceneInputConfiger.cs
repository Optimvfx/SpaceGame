using UnityEngine;

public class GameSceneInputConfiger : GameSceneLoadEvent
{
    [Header("Input")]
    [SerializeField] private PlayerInput _pcInput;
    [SerializeField] private PlayerInputMobile _mobileInput;

    public override void OnSceneLoaded(GameSceneArguments argument)
    {
        SellectInput(argument);
    }

    private void SellectInput(GameSceneArguments argument)
    {
        _pcInput.enabled = argument.DeviceIsMobile == false;
        _mobileInput.enabled = argument.DeviceIsMobile;
    }
}

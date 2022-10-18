using UnityEngine;
using IJunior.TypedScenes;

public class GameSceneConfiger : MonoBehaviour, ISceneLoadHandler<GameSceneArguments>
{
    [SerializeField] private StandartSpawnByTime _meteorSpawnByTime;
    [SerializeField] private TopMenu _topMenu;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private UFloat _meteorHardnesModiffier;

    public void OnSceneLoaded(GameSceneArguments argument)
    {
         _meteorSpawnByTime.StartSpawn(_meteorHardnesModiffier/(argument.HardnesLevel + 1));
        _topMenu.Init(argument.PlayerTop);
        _playerInventory.AddMoney(argument.HardnesLevel);
    }
}

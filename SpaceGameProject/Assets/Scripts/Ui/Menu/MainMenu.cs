using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class MainMenu : Menu
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _playButton;

    private bool _goToGame = false;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(Exit);
        _playButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(Exit);
        _playButton.onClick.RemoveListener(StartGame);
    }


    private async void StartGame()
    {
        if (_goToGame)
            return;

        _goToGame = true;

        GameScene.Load(new GameSceneArguments(await SpaceGameApiFactory.StandartSpaceGameApi.GetMoney(), await SpaceGameApiFactory.StandartSpaceGameApi.GetTop()));
    }

    private void Exit()
    {
        Application.Quit();
    }
}

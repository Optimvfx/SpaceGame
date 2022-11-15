using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private bool _canEnterNotLoadedGame;

    private bool _goingToGame = false;

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
        if (_goingToGame)
            return;

        Time.timeScale = 1;

        var hardnes = await SpaceGameApiSingleton.StandartSpaceGameApi.GetMoney();
        var top = await SpaceGameApiSingleton.StandartSpaceGameApi.GetTop();

        GameScen.Load(new GameSceneArguments(hardnes, top, Application.isMobilePlatform));
        _goingToGame = true;
    }

    private void Exit()
    {
        Application.Quit();
    }
}

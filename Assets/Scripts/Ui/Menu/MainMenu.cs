using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        _playButton.onClick.AddListener(TryStartGame);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(Exit);
        _playButton.onClick.RemoveListener(TryStartGame);
    }

    private async void TryStartGame()
    {
        if (_goingToGame)
            return;

        Time.timeScale = 1;

        var loadArguments = await GetGameLoadArguments();

        if (loadArguments == null)
            return;

         GameScen.LoadAsync(loadArguments);

        _goingToGame = true;
    }

    private async Task<GameSceneArguments> GetGameLoadArguments()
    {
        uint hardnes;
        TopMenu.PlayerTop top;

        try
        {
            WebApi.PrintJSLine("1");

            hardnes = await SpaceGameApiSingleton.StandartSpaceGameApi.GetMoney();

            WebApi.PrintJSLine("3");

            top = await SpaceGameApiSingleton.StandartSpaceGameApi.GetTop();

            WebApi.PrintJSLine("4");

            return new GameSceneArguments(hardnes, top, Application.isMobilePlatform);

            WebApi.PrintJSLine("5");
        }
        catch(Exception ex)
        {
            WebApi.PrintJSLine(ex.ToString() + ex.Message + ex.StackTrace + ex.Source);

            return null;
        }

        try
        {
        }
        catch
        {
            hardnes = SpaceGameApiSingleton.StandartSpaceGameApi.VirtualScore;
            top = new TopMenu.PlayerTop(new List<TopMenu.PlayerInfo>());

            if (_canEnterNotLoadedGame)
            {
                return (new GameSceneArguments(hardnes, top, Application.isMobilePlatform));
            }

            return null;
        }
    }

    private void Exit()
    {
        Application.Quit();
    }
}

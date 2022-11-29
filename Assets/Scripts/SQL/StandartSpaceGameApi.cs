using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class StandartSpaceGameApi : ISpaceGameApi
{
    private const string _authorizationHeaderName = "Authorization";

    private const string _url = "https://cometaclub.net/";

    private const string _levelUpAsk = "refapi/games/levelUp";
    private const string _getBalanceAsk = "refapi/games/balance";
    private const string _getTopAsk = "refapi/games/top";

    private readonly HttpClient _httpClient;
    private readonly RequestParser _requestParser;

    public uint VirtualScore { get; private set; }

    public StandartSpaceGameApi()
    {
        _httpClient = new HttpClient();
        _requestParser = new RequestParser();
    }

    public void Authorise(string key)
    {
        _httpClient.DefaultRequestHeaders.Add(_authorizationHeaderName, key);
    }

    public async Task<uint> GetMoney()
    {
        const int _totalFeildIndex = 1;
        const int _totalValueStartIndex = 8;

        var totalString = (await GetAsk(_getBalanceAsk))[_totalFeildIndex].Replace('.', ',').Substring(_totalValueStartIndex);

        var totalValue = double.Parse(totalString);

        return (uint)totalValue;
    }

    public async Task<TopMenu.PlayerTop> GetTop()
    {
        const int _startPlayerInfoOffset = 3;
        const int _playerInfoOffset = 5;

        const int _playerNameFieldIndex = 0;
        const int _playerMoneyFieldIndex = 1;

        var topStrings = await GetAsk(_getTopAsk);

        var playerTop = new List<TopMenu.PlayerInfo>();

        for(var i = _startPlayerInfoOffset; i < topStrings.Count; i += _playerInfoOffset)
        {
            var loginString = topStrings[i + _playerNameFieldIndex].Substring(9);
            loginString = loginString.Remove(loginString.Length - 2);

            var moneyString = topStrings[i + _playerMoneyFieldIndex].Substring(11).Replace('.', ',');

            var login = loginString;
            var money = double.Parse(moneyString);

            playerTop.Add(new TopMenu.PlayerInfo(login, (uint)money));
        }

        return  new TopMenu.PlayerTop(playerTop);
    }

    public void LevelUp()
    {
        PushAsk(_levelUpAsk);
    }

    public void SetVirtualScore(uint score)
    {
        VirtualScore = score;
    }

    private async void PushAsk(string askTarget)
    {
        var result = await _httpClient.GetAsync(GetUrl(askTarget));

        if (result.IsSuccessStatusCode == false)
            throw new HttpRequestException();
    }

    private async Task<List<string>> GetAsk(string askTarget)
    {
        var result = await _httpClient.GetAsync(GetUrl(askTarget));

        if (result != null && result.IsSuccessStatusCode)
        {
            try
            {
                var jsonString = await result.Content.ReadAsStringAsync();
                return _requestParser.Parse(jsonString);
            }
            catch
            {
                throw new HttpRequestException();
            }
        }

        throw new HttpRequestException(result.StatusCode.ToString());
    }

    private string GetUrl(string extraArguments)
    {
        return _url + extraArguments;
    }
}

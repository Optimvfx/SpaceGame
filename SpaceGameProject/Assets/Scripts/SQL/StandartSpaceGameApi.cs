using Newtonsoft.Json;
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

    public uint VirtualScore { get; private set; }

    public StandartSpaceGameApi()
    {
        _httpClient = new HttpClient();
    }

    public void Authorise(string key)
    {
        _httpClient.DefaultRequestHeaders.Add(_authorizationHeaderName, key);
    }

    public async Task<uint> GetMoney()
    {
        var balanse = await GetAsk<Balance>(_getBalanceAsk);

        return balanse.Total + VirtualScore;
    }

    public async Task<TopMenu.PlayerTop> GetTop()
    {
        var players = await GetAsk<List<Player>>(_getTopAsk);

        return new TopMenu.PlayerTop(players.Select(player => new TopMenu.PlayerInfo(player.Login, player.Money)));
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

    private async Task<T> GetAsk<T>(string askTarget)
    {
        var result = await _httpClient.GetAsync(GetUrl(askTarget));

        if (result != null && result.IsSuccessStatusCode)
        {
            try
            {
                var jsonString = result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString.Result);
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

    public class Balance
    {
        [JsonProperty("total")]
        public uint Total { get; private set; }

        [JsonProperty("level")]
        public uint Level { get; private set; }

        [JsonProperty("withdrawn")]
        public uint Withdrawn { get; private set; }

        [JsonProperty("available")]
        public uint Available { get; private set; }

        [JsonProperty("limit")]
        public uint Limit { get; private set; }
    }

    public class Player
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("login")]
        public string Login { get; private set; }

        [JsonProperty("cometics")]
        public uint Money { get; private set; }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseGameAPI : ISpaceGameApi
{
	protected string _authKey;
	protected const string _authorizationHeaderName = "Authorization";

	private const string _url = "https://cometaclub.net/";

	private const string _levelUpAsk = "refapi/games/levelUp";
	private const string _getBalanceAsk = "refapi/games/balance";
	private const string _getTopAsk = "refapi/games/top";

	public uint VirtualScore { get; private set; }

	public async Task<uint> GetMoney()
	{
		const int _totalFeildIndex = 1;
		const int _totalValueStartIndex = 8;

		var response = await GetAsk(_getBalanceAsk);
		if (response == null || response.Count <= _totalFeildIndex)
			throw new System.Exception("[GetMoney] response is null or empty");
		var totalString = response[_totalFeildIndex].Replace('.', ',')
			.Substring(_totalValueStartIndex);

		//Debug.Log("[GetMoney] response: " + string.Join(",", response));
		var totalValue = (uint)double.Parse(totalString);
		return totalValue;
	}

	public async Task<TopMenu.PlayerTop> GetTop()
	{
		const int _startPlayerInfoOffset = 3;
		const int _playerInfoOffset = 5;

		const int _playerNameFieldIndex = 0;
		const int _playerMoneyFieldIndex = 1;

		var topStrings = await GetAsk(_getTopAsk);

		var playerTop = new List<TopMenu.PlayerInfo>();

		for (var i = _startPlayerInfoOffset; i < topStrings.Count; i += _playerInfoOffset)
		{
			var loginString = topStrings[i + _playerNameFieldIndex].Substring(9);
			loginString = loginString.Remove(loginString.Length - 2);

			var moneyString = topStrings[i + _playerMoneyFieldIndex].Substring(11).Replace('.', ',');

			var login = loginString;
			var money = double.Parse(moneyString);

			playerTop.Add(new TopMenu.PlayerInfo(login, (uint)money));
		}

		return new TopMenu.PlayerTop(playerTop);
	}

	public void LevelUp()
	{
		PushAsk(_levelUpAsk);
	}

	public void SetVirtualScore(uint score)
	{
		VirtualScore = score;
	}
	
	public virtual void Authorise(string key)
	{
		_authKey = key;
	}

	protected abstract void PushAsk(string askTarget);
	protected abstract Task<List<string>> GetAsk(string askTarget);

	protected string GetUrl(string extraArguments)
	{
		return _url + extraArguments;
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class WebGLGameAPI : BaseGameAPI
{
	protected override async void PushAsk(string askTarget)
	{
		UnityWebRequest request = UnityWebRequest.Get(GetUrl(askTarget));
		request.SetRequestHeader(_authorizationHeaderName, _authKey);
		await request.SendWebRequest();

		if (!request.isDone)
		{
			throw new System.Exception(request.error + "\n" + request.responseCode);
		}
	}

	protected override async Task<List<string>> GetAsk(string askTarget)
	{
		UnityWebRequest request = UnityWebRequest.Get(GetUrl(askTarget));
		request.SetRequestHeader(_authorizationHeaderName, _authKey);
		await request.SendWebRequest();

		if (request.isDone && request.downloadHandler != null)
		{
			try
			{
				Debug.LogWarning(request.downloadHandler.text);
				if (request.downloadHandler.text.Contains("Not authorized"))
				{
					Storage.PrintJSLine("Player not authorized");
				}
				else
				{
					return RequestParser.Parse(request.downloadHandler.text);
				}
			}
			catch
			{
				throw new System.Exception(request.error + "\n" + request.responseCode);
			}
		}

		throw new System.Exception(request.error + "\n" + request.responseCode);
	}
}
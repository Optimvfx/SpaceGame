using UnityEngine;

public static class SpaceGameApiSingleton
{
    
    private const string _apiKeyTokenKey = "token";

    private static ISpaceGameApi _gameAPI;

    public static ISpaceGameApi GameAPI
    {
        get
        {
            if (_gameAPI == null)
            {
//#if UNITY_WEBGL && !UNITY_EDITOR
#if UNITY_WEBGL
                _gameAPI = new WebGLGameAPI();
#else
                _gameAPI = new StandaloneGameAPI();
#endif
                _gameAPI.Authorise(GetApiKey());
            }

            return _gameAPI;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void CleanupGameAPI()
    {
        _gameAPI = null;
    }

    private static string GetApiKey()
    {
        var apiKey = Storage.GetString(_apiKeyTokenKey);

        Storage.PrintJSLine("2 " + apiKey);

        return apiKey;
    }
}

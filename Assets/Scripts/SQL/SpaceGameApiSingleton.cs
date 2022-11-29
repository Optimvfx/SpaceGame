using UnityEngine;

public static class SpaceGameApiSingleton
{
    private const string _apiKeyTokenKey = "token";

    private static StandartSpaceGameApi _standartSpaceGameApi;

    public static StandartSpaceGameApi StandartSpaceGameApi
    {
        get
        {
            if (_standartSpaceGameApi == null)
            {
                _standartSpaceGameApi = new StandartSpaceGameApi();
                _standartSpaceGameApi.Authorise(GetApiKey());
            }

            return _standartSpaceGameApi;
        }
    }

    private static string GetApiKey()
    {
        var apiKey = WebApi.GetString(_apiKeyTokenKey);

        WebApi.PrintJSLine("2 " + apiKey);

        return apiKey;

        throw new System.NullReferenceException();
    }
}

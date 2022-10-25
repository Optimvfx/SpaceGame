using UnityEngine;
using WebPrefasSpace;

public static class SpaceGameApiFactory
{
    private const string _apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE0Iiwicm9sZSI6IlVzZXIiLCJuYmYiOjE2NjY3MjY3MzMsImV4cCI6MTY2NzMzMTUzMywiaXNzIjoibG9jYWxob3N0IiwiYXVkIjoibG9jYWxob3N0In0.XSjAvNYSxd1bVNLm6CnD03MceI0K3HsfEDbnMl8Hlgg";

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
        if (WebPrefs.HasKey(_apiKeyTokenKey))
            return WebPrefs.GetString(_apiKeyTokenKey);
        else
            return _apiKey;
    }
}

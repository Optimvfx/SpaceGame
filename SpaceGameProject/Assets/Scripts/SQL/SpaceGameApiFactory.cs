using UnityEngine;
using WebPrefasSpace;

public static class SpaceGameApiFactory
{
    private const string _apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE0Iiwicm9sZSI6IlVzZXIiLCJuYmYiOjE2NjY5NTMyNTcsImV4cCI6MTY2NzU1ODA1NywiaXNzIjoibG9jYWxob3N0IiwiYXVkIjoibG9jYWxob3N0In0.Ljsc9Bt3vNcsguxdQTwS5bhSMo9BrBk5YkQZAalNUwQ";

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

        throw new System.NullReferenceException();
    }
}

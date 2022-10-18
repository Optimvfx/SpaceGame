using UnityEngine;
using WebPrefasSpace;

public static class SpaceGameApiFactory
{
    private const string _apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJyb2xlIjoiQWRtaW4iLCJuYmYiOjE2NjU5OTY5ODUsImV4cCI6MTY2NjYwMTc4NSwiaXNzIjoibG9jYWxob3N0IiwiYXVkIjoibG9jYWxob3N0In0.IjP46BGXK1FOtEC4m_9Kzt8rSD51bgIKpicp9sydWsU";

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

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class StandaloneGameAPI : BaseGameAPI
{
    private readonly HttpClient _httpClient;
    
    public StandaloneGameAPI()
    {
        _httpClient = new HttpClient();
    }

    public override void Authorise(string key)
    {
        _httpClient.DefaultRequestHeaders.Add(_authorizationHeaderName, key);
    }
    
    protected override async void PushAsk(string askTarget)
    {
        var result = await _httpClient.GetAsync(GetUrl(askTarget));

        if (result.IsSuccessStatusCode == false)
            throw new HttpRequestException();
    }

    protected override async Task<List<string>> GetAsk(string askTarget)
    {
        var result = await _httpClient.GetAsync(GetUrl(askTarget));

        if (result != null && result.IsSuccessStatusCode)
        {
            try
            {
                var jsonString = await result.Content.ReadAsStringAsync();
                return RequestParser.Parse(jsonString);
            }
            catch
            {
                throw new HttpRequestException();
            }
        }

        throw new HttpRequestException(result.StatusCode.ToString());
    }
}

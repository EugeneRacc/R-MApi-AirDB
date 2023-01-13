using System.Net;
using RickAndMortyBLL.Exceptions;

namespace RickAndMortyBLL;

public static class HelperService
{
    public const string characterUrl = "https://rickandmortyapi.com/api/character";
    public const string episodeUrl = "https://rickandmortyapi.com/api/episode";
    public const string locationUrl = "https://rickandmortyapi.com/api/location";

    private static async Task<string> SendRequest(string url)
    {
        HttpResponseMessage responseMessage;
        using (var http = new HttpClient())
        {
            responseMessage = await http.GetAsync(url);
        }
        if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            throw new RickAndMortyException("Characters or episode with such name doesn't exist");
        return await responseMessage.Content.ReadAsStringAsync();
    }
    
    private static T? ConvertJsonToObject<T>(string json)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
    }

    public static async Task<T?> RequestWithObject<T>(string url)
    {
        var json = await SendRequest(url);
        return ConvertJsonToObject<T>(json);
    }
}
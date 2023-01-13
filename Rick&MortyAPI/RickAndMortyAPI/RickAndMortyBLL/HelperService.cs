namespace RickAndMortyBLL;

public static class HelperService
{
    public static async Task<string> SendRequest(string url)
    {
        using (var http = new HttpClient())
        {
            return await http.GetStringAsync(url);
        }
    }
    
    public static T? ConvertJsonToObject<T>(string json)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
    }
}
using Newtonsoft.Json.Linq;
using RickAndMortyBLL.Interfaces;
using RickAndMortyBLL.Models;

namespace RickAndMortyBLL.Services;

public class PersonService : IPersonService
{
    public async Task<PersonModel> GetPersonDetails(string name)
    {
        string data;
        using (var http = new HttpClient())
        {
            data = 
                await http.GetStringAsync(
                    $"https://rickandmortyapi.com/api/character?name={name}");
        }
        var jToken = GetValue(data, "results")[0];
        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonModel>(jToken.ToString());
        var locationUrl = jToken["origin"]["url"];
        using (var http = new HttpClient())
        {
            data = 
                await http.GetStringAsync(
                    locationUrl.ToString());
        }

        result.Origin = Newtonsoft.Json.JsonConvert.DeserializeObject<OriginModel>(data);
        return result;
    }

    public async Task<bool> CheckIfPersonInEpisode(PersonInEpisodeModel personInEpisodeModel)
    {
        string data;
        using (var http = new HttpClient())
        {
            data = 
                await http.GetStringAsync("https://rickandmortyapi.com/api/character");
        }
        return true;
    }

    public JToken GetValue(string json, string element)
    {
        JObject jObject = JObject.Parse(json);
        JToken jUser = jObject[$"{element}"];
        return jUser;
    }
    
}
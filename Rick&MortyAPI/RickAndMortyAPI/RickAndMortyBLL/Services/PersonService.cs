using Newtonsoft.Json.Linq;
using RickAndMortyBLL.Exceptions;
using RickAndMortyBLL.Interfaces;
using RickAndMortyBLL.Models;
using RickAndMortyBLL.Models.RickAndMortyResponseModels.Character;

namespace RickAndMortyBLL.Services;

public class PersonService : IPersonService
{
    public async Task<PersonModel> GetPersonDetails(string name)
    {
        var data = await HelperService.SendRequest($"https://rickandmortyapi.com/api/character?name={name}");
        var resultObject = HelperService.ConvertJsonToObject<CharacterModelResponse>(data);
        if (resultObject == null)
            throw new RickAndMortyException("Characters with such name doesn't exist");
        var firstCharacter = resultObject.Results.ToList()[0];
        var originJson = await HelperService.SendRequest(firstCharacter.Origin.Url);
        var originModel = HelperService.ConvertJsonToObject<OriginModel>(originJson);
        var characterModel = new PersonModel()
        {
            Name = firstCharacter.Name,
            Gender = firstCharacter.Gender,
            Origin = new OriginModel()
            {
                Name = originModel.Name,
                Dimension = originModel.Dimension,
                Type = originModel.Type
            },
            Species = firstCharacter.Species,
            Status = firstCharacter.Status,
            Type = firstCharacter.Type
        };
        return characterModel;
    }

    public async Task<bool> CheckIfPersonInEpisode(PersonInEpisodeModel personInEpisodeModel)
    {
        var data = await HelperService.SendRequest(
            $"https://rickandmortyapi.com/api/character?name={personInEpisodeModel.PersonName}");
        dynamic rsu = JObject.Parse(data);
        Console.WriteLine(rsu.results[0].id);
        return true;
    }
}
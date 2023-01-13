using AutoMapper;
using Newtonsoft.Json.Linq;
using RickAndMortyBLL.Exceptions;
using RickAndMortyBLL.Interfaces;
using RickAndMortyBLL.Models;
using RickAndMortyBLL.Models.RickAndMortyResponseModels.Character;

namespace RickAndMortyBLL.Services;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;

    public PersonService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IEnumerable<PersonModel>> GetPersonDetails(string name)
    {
        var data = await HelperService.SendRequest($"https://rickandmortyapi.com/api/character?name={name}");
        var resultObject = HelperService.ConvertJsonToObject<CharacterModelResponse>(data);
        if (resultObject == null)
            throw new RickAndMortyException("Characters with such name doesn't exist");
        var resultDetails = new List<PersonModel>();
        foreach (var character in resultObject.Results)
        {
            if (string.IsNullOrEmpty(character.OriginUrls.Url))
            {
                var mappedPM = _mapper.Map<PersonModel>(character);
                mappedPM.Origin = new OriginModel()
                {
                    Name = character.OriginUrls.Name
                };
                resultDetails.Add(mappedPM);
                continue;
            }
            var originJson = await HelperService.SendRequest(character.OriginUrls.Url);
            var originModel = HelperService.ConvertJsonToObject<OriginModel>(originJson);
            var mappedPMWO = _mapper.Map<PersonModel>(character);
            mappedPMWO.Origin = _mapper.Map<OriginModel>(originModel);
            resultDetails.Add(mappedPMWO);
        }
        return resultDetails; 
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
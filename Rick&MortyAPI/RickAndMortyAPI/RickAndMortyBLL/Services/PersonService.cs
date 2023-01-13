using AutoMapper;
using RickAndMortyBLL.Exceptions;
using RickAndMortyBLL.Interfaces;
using RickAndMortyBLL.Models;
using RickAndMortyBLL.Models.RickAndMortyResponseModels.Character;
using RickAndMortyBLL.Models.RickAndMortyResponseModels.Episode;

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
        var resultObject = await HelperService.RequestWithObject<CharacterModelResponse>($"https://rickandmortyapi.com/api/character?name={name}");
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
            var originModel = await HelperService.RequestWithObject<OriginModel>(character.OriginUrls.Url);
            var mappedPMWO = _mapper.Map<PersonModel>(character);
            mappedPMWO.Origin = _mapper.Map<OriginModel>(originModel);
            resultDetails.Add(mappedPMWO);
        }
        return resultDetails; 
    }

    public async Task<bool> CheckIfPersonInEpisode(PersonInEpisodeModel personInEpisodeModel)
    {
        var personModel = await HelperService.RequestWithObject<CharacterModelResponse>(
            $"https://rickandmortyapi.com/api/character?name={personInEpisodeModel.PersonName}");
        var episodeModels = await HelperService.RequestWithObject<EpisodeModelResponse>(
                $"https://rickandmortyapi.com/api/episode?name={personInEpisodeModel.EpisodeName}");
        var possiblePersonIds = personModel.Results.Select(x => x.Id);
        var charactersIdsInEpisode = episodeModels.Results
            .SelectMany(x => x.Characters)
            .SelectMany(character => character.Split("/").TakeLast(1))
            .Select(id => int.TryParse(id, out var intId) ? intId : -1)
            .Where(id => id >= 0);
        var result = charactersIdsInEpisode.Intersect(possiblePersonIds).Any();
        return result;
    }
}
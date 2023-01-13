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
        var resultObject = await HelperService.RequestWithObject<CharacterModelResponse>($"{HelperService.characterUrl}?name={name}");
        if (resultObject == null)
            throw new RickAndMortyException("Characters with such name doesn't exist");
        var resultDetails = new List<PersonModel>();
        foreach (var character in resultObject.Results)
        {
            var mappedCharacter = _mapper.Map<PersonModel>(character);
            mappedCharacter.Origin = await GetOrigin(character.OriginUrls);
            resultDetails.Add(mappedCharacter);
        }
        return resultDetails; 
    }

    public async Task<bool> CheckIfPersonInEpisode(PersonInEpisodeModel personInEpisodeModel)
    {
        var personModel = await HelperService.RequestWithObject<CharacterModelResponse>(
            $"{HelperService.characterUrl}?name={personInEpisodeModel.PersonName}");
        var episodeModels = await HelperService.RequestWithObject<EpisodeModelResponse>(
                $"{HelperService.episodeUrl}?name={personInEpisodeModel.EpisodeName}");
        if (personModel == null || episodeModels == null)
            throw new RickAndMortyException(
                "No such episode or character. Try to input correct values or return later");
        var possiblePersonIds = personModel.Results.Select(x => x.Id);
        var charactersIdsInEpisode = episodeModels.Results
            .SelectMany(episode => episode.Characters)
            .SelectMany(character => character.Split("/").TakeLast(1))
            .Select(id => int.TryParse(id, out var intId) ? intId : -1)
            .Where(id => id >= 0);
        var result = charactersIdsInEpisode.Intersect(possiblePersonIds).Any();
        return result;
    }

    private async Task<OriginModel> GetOrigin(OriginUrlsModel originUrlsModel)
    {
        if (string.IsNullOrEmpty(originUrlsModel.Url))
        {
            return new OriginModel()
            {
                Name = originUrlsModel.Name
            };
        }

        return await HelperService.RequestWithObject<OriginModel>(originUrlsModel.Url)
            ??
            new OriginModel()
            {
                Name = originUrlsModel.Name
            };
    }
}
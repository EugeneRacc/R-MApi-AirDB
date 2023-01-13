using Newtonsoft.Json.Linq;
using RickAndMortyBLL.Models;

namespace RickAndMortyBLL.Interfaces;

public interface IPersonService
{
    public Task<IEnumerable<PersonModel>> GetPersonDetails(string name);
    public Task<bool> CheckIfPersonInEpisode(PersonInEpisodeModel personInEpisodeModel);
}
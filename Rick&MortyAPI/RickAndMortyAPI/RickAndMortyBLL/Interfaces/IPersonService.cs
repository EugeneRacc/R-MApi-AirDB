using RickAndMortyBLL.Models;

namespace RickAndMortyBLL.Interfaces;

public interface IPersonService
{
    public Task<PersonModel> GetPersonDetails();
}
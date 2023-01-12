using RickAndMortyBLL.Interfaces;
using RickAndMortyBLL.Models;

namespace RickAndMortyBLL.Services;

public class PersonService : IPersonService
{
    public async Task<PersonModel> GetPersonDetails()
    {
        return new PersonModel();
    }
}
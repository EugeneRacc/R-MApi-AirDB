namespace RickAndMortyBLL.Models.RickAndMortyResponseModels.Character;

public class CharacterModelResponse
{
    public InfoModel Info { get; set; }
    public IEnumerable<PersonModelResponse> Results { get; set; }
}
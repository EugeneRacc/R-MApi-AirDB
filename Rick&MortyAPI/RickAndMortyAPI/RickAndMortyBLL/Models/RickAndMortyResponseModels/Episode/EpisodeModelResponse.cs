namespace RickAndMortyBLL.Models.RickAndMortyResponseModels.Episode;

public class EpisodeModelResponse
{
    public InfoModel Info { get; set; }
    public IEnumerable<EpisodeDetailsModel> Results { get; set; }
}
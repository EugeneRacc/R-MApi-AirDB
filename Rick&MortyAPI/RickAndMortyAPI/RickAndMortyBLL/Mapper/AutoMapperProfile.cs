using AutoMapper;
using RickAndMortyBLL.Models;
using RickAndMortyBLL.Models.RickAndMortyResponseModels.Character;

namespace RickAndMortyBLL.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PersonModel, PersonModelResponse>()
            .ForMember(x => x.OriginUrls, 
                opt => opt.Ignore())
            .ForMember(x => x.Url, 
                opt => opt.Ignore())
            .ForMember(x => x.Location, 
                opt => opt.Ignore())
            .ForMember(x => x.Image, 
                opt => opt.Ignore())
            .ForMember(x => x.Episode, 
                opt => opt.Ignore())
            .ForMember(x => x.Created, 
                opt => opt.Ignore())
            .ReverseMap();
        
        CreateMap<OriginModel, OriginModel>()
            .ReverseMap();
    }
}
using AutoMapper;
using manga.Domain.Dtos;
using mangas.Domain.Entities;

namespace manga.Services.MappingsM;

public class ResponseMappingProfile : Profile
{
    public ResponseMappingProfile()
    {
        CreateMap<Manga, MangaDTO>()
        .ForMember(
            dest => dest.PublicationYear,
            opt => opt.MapFrom(src => src.PublicationDate.Date.Year)
        );
    }

}
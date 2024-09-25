using AutoMapper;
using manga.Domain.Dtos;
using mangas.Domain.Entities;

namespace manga.Services.Mappings
{
    public class RequestUpdateMappingProfile : Profile
    {
        public RequestUpdateMappingProfile()
        {
           
            CreateMap<MangaUpdateDTO, Manga>()
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.PublicationYear));
        }
    }
}

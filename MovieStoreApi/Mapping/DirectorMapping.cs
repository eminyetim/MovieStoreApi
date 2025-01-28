using AutoMapper;
using Microsoft.Data.SqlClient;
using MovieStoreApi.Dtos.DirectorDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Mapping
{
    public class DirectorMapping : Profile
    {
        public DirectorMapping()
        {
            CreateMap<Person,CreateDirectorDto>();
            CreateMap<CreateDirectorDto,Director>();

            CreateMap<Director,SelectDirectorDto>() // Actor to 
                .ForMember(dest => dest.Name,opt => opt.MapFrom(src=>src.person.Name))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src=>src.person.Phone))
                .ForMember(dest => dest.BirthDate , opt=> opt.MapFrom(src => src.person.BirthDate))
                .ForMember(dest => dest.Movies , opt => opt.MapFrom(src => src.Movies.Select(ma => ma.Name)))
                .ReverseMap();
        }
    }
}
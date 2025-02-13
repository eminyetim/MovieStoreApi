using AutoMapper;
using MovieStoreApi.Dtos.GenreDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Mapping
{
    public class GenreMapping : Profile
    {
        public GenreMapping()
        {
            CreateMap<CreateGenreDto, Genre>(); // CreateGenreDto 'yu Genre ye mapler.
            CreateMap<Genre, SelectGenreDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                            .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres.Select(a=>a.Movie.Name)))
                                            .ForMember(dest => dest.CustomerFavoriteGenres, opt => opt.MapFrom(src => src.CustomerFavoriteGenres.Select(a=>a.Customer.Person.Name)));
        }
    }
}
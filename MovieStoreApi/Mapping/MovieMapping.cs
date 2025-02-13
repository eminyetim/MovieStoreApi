using AutoMapper;
using Microsoft.Data.SqlClient;
using MovieStoreApi.Dtos.MovieDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Mapping
{
    public class MovieMapping : Profile
    {
        public MovieMapping()
        {
            CreateMap<CreateMovieDto,Movie>();
            
            CreateMap<Movie,SelectMovieDto>()
                .ForMember(dest=>dest.Name , opt=> opt.MapFrom(src=>src.Name))
                .ForMember(dest=>dest.Price,opt => opt.MapFrom(src=>src.Price))
                .ForMember(dest=>dest.ReleaseDate,opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest=>dest.DirectorName,opt=> opt.MapFrom(src => src.Director.person.Name)) // Bir tane yönetici var 
                .ForMember(dest=> dest.Actor,opt=>opt.MapFrom(src=>src.movieActors.Select(ma=>ma.Actor.Person.Name))); // Birden fazla favori var Select ile yapıldı.

            CreateMap<UpdateMovieDto,Movie>();
        }
    }
}
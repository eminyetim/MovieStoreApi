using AutoMapper;
using MovieStoreApi.Dtos.ActorDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Mapping
{
    public class ActorMapping : Profile
    {
        public ActorMapping()
        {
            CreateMap<CreateActorDto, Actor>().ReverseMap();
            CreateMap<CreateActorDto, Person>().ReverseMap();
            CreateMap<UpdateActorDto, Actor>().ReverseMap();
            
            CreateMap<Actor, SelectActorDto>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                 .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Person.BirthDate))
                 .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Phone))
                 .ReverseMap();
           // CreateMap<SelectActorDto, Person>().ReverseMap();

        }
    }
}
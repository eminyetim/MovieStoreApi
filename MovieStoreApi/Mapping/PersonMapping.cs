using AutoMapper;
using MovieStoreApi.Dtos.PersonDto;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Mapping
{
    public class PersonMapping : Profile 
    {
        public PersonMapping()
        {
            CreateMap<Person,SelectPersonDto>();
            CreateMap<CreatePersonDto,Person>().ReverseMap();
            CreateMap<UpdatePersonDto,Person>();
        }
    }
}
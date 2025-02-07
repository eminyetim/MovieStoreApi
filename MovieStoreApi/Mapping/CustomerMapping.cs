using AutoMapper;
using MovieStoreApi.Dtos.CustomerDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Person, CreateCustomerDto>(); // Person ı CreateCustomerDto ya mapliyor.

            CreateMap<Customer, SelectCustomerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Person.BirthDate))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Person.Phone))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.Person.CreateDate))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id)); // Customer Id değeri personel id değil.
        }
    }
}
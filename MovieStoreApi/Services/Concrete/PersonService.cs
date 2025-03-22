using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Dtos.PersonDto;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly UserManager<Person> _context;
        
        private readonly IMapper _mapper;


        public PersonService(UserManager<Person> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatePersonDto> AddPersonAsync(CreatePersonDto person)
        {
            var user = new Person
            {
                UserName = person.Email,
                Email = person.Email,
                Name = person.Name,
                BirthDate = person.BirthDate,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _context.CreateAsync(user, person.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Kullanıcı oluşturulamadı: {errors}");
            }

            return person;
        }

        public async Task DeletePersonAsync(string id)
        {
            var result = await _context.FindByIdAsync(id);
            if (result == null)
                throw new Exception("Person is could not be find!");
           await _context.DeleteAsync(result);
           
        }

       

        public async Task<IEnumerable<SelectPersonDto?>> GetAllPersonsAsync()
        {
            var result = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<SelectPersonDto>>(result);
        }

        public async Task<SelectPersonDto?> GetPersonByEmailAsync(string email)
        {
            var result = await _context.FindByEmailAsync(email);
            if (result == null)
                throw new Exception("Person is could not be find!");
            return _mapper.Map<SelectPersonDto>(result);
        }

      
        public async Task UpdatePersonAsync(UpdatePersonDto person)
        {
            var result = await _context.FindByEmailAsync(person.email);
            if (result == null)
                throw new Exception("Person is could not be find!");
            _mapper.Map(person,result); // persondan resulta değerleri aktar.
            await _context.UpdateAsync(result);
           
        }

    }
}
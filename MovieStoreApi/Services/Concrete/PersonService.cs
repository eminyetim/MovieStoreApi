using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Dtos.PersonDto;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public PersonService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatePersonDto> AddPersonAsync(CreatePersonDto person)
        {
            var result = _mapper.Map<Person>(person);
            await _context.Persons.AddAsync(result);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task DeletePersonAsync(int id)
        {
            var result = await _context.Persons.FirstOrDefaultAsync(pers => pers.Id == id);
            if (result == null)
                throw new Exception("Person is could not be find!");
            _context.Persons.Remove(result);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<SelectPersonDto?>> GetAllPersonsAsync()
        {
            var result = await _context.Persons.ToListAsync();
            return _mapper.Map<IEnumerable<SelectPersonDto>>(result);
        }

        public async Task<SelectPersonDto?> GetPersonByIdAsync(int id)
        {
            var result = await _context.Persons.FirstOrDefaultAsync(pers => pers.Id == id);
            if (result == null)
                throw new Exception("Person is could not be find!");
            return _mapper.Map<SelectPersonDto>(result);
        }

        public async Task UpdatePersonAsync(UpdatePersonDto person)
        {
            var result = await _context.Persons.FirstOrDefaultAsync(pers => pers.Id == person.Id);
            if (result == null)
                throw new Exception("Person is could not be find!");
            _mapper.Map(person,result); // persondan resulta değerleri aktar.
            _context.Persons.Update(result);
            _context.SaveChanges();
        }

    }
}
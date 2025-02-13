using System.IO.Compression;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Dtos.DirectorDtos;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class DirectorService : IDirectorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DirectorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateDirectorDto> AddDirectorAsync(CreateDirectorDto director)
        {
            var person = new Person
            {
                Name = director.Name,
                BirthDate = director.BirthDate,
                Phone = director.Phone
            };
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            var directorNew = new Director
            {
                PersonId = person.Id
            };

            await _context.Directors.AddAsync(directorNew);
            await _context.SaveChangesAsync();

            return _mapper.Map<CreateDirectorDto>(person);
        }

        public async Task<bool> DeleteDirectorAsync(int id)
        {
            var director = await _context.Directors.Include(a => a.person).FirstOrDefaultAsync(direc => direc.Id == id);
            if (director == null)
                throw new Exception("Director id is could not be find.");
            _context.Persons.Remove(director.person);
            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SelectDirectorDto>> GetAllDirectorsAsync()
        {
            var result = await _context.Directors
                .Include(a => a.person)
                .Include(a => a.Movies).ToListAsync();
            return _mapper.Map<IEnumerable<SelectDirectorDto>>(result);
        }

        public async Task<SelectDirectorDto?> GetDirectorByIdAsync(int id)
        {
            var test = await _context.Directors.FirstOrDefaultAsync(a => a.Id == id);
            if(test == null)
                throw new Exception("Director is could not be find!");
            var result = await _context.Directors
                        .Include(a => a.person)
                        .Include(a => a.Movies).FirstOrDefaultAsync(direct => direct.Id == id);
            return _mapper.Map<SelectDirectorDto>(result);
        }

        public async Task<bool> UpdateDirectorAsync(UpdateDirectorDto director)
        {
            var findDirector = await _context.Directors.Include(a => a.person).FirstOrDefaultAsync(direct => direct.Id == director.Id);
            if(findDirector == null)
                throw new Exception("Director is could not be find!");

            findDirector.person.Name = director.Name;
            findDirector.person.Phone = director.Phone;
            findDirector.person.BirthDate = director.BirthDate;     

            _context.Directors.Update(findDirector);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
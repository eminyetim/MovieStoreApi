using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MovieStoreApi.Dtos.ActorDtos;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ActorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateActorDto> AddActorAsync(CreateActorDto createActorDto)
        {
            var person = new Person
            {
                Name = createActorDto.Name,
                BirthDate = createActorDto.BirthDate,
                Phone = createActorDto.Phone,
            };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync(); // Person ID'si oluşturulur.

            // 2. Yeni Actor oluştur ve Person ile ilişkilendir
            var actor = new Actor
            {
                PersonId = person.Id,
            };

            _context.Actors.Add(actor);
            await _context.SaveChangesAsync(); // Actor kaydedilir.

            return _mapper.Map<CreateActorDto>(person);
        }

        public async Task<bool> DeleteActor(int id)
        {
            // 1. Actor kaydını bul ve Person ile ilişkilendir
            var actor = await _context.Actors.Include(a => a.Person).FirstOrDefaultAsync(a => a.Id == id);

            // 2. Eğer Actor bulunamazsa false döndür
            if (actor == null)
            {
                return false;
            }
            // 3. Actor ile ilişkili Person kaydını sil
            _context.Persons.Remove(actor.Person);
            // 4. Actor kaydını sil
            _context.Actors.Remove(actor);
            // 5. Değişiklikleri kaydet
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<SelectActorDto?> GetActorByIdAsync(int id)
        {
            var result = await _context.Actors
            .Include(a => a.Person) // Actor ile ilişkili Person bilgilerini getir
            .Include(a => a.MovieActors) // Actor ile ilişkili MovieActors bilgilerini getir
                .ThenInclude(ma => ma.Movie) // MovieActors ile ilişkili Movie bilgilerini getir
            .FirstOrDefaultAsync(a => a.Id == id); // Belirli bir Actor ID'sine göre getir
            return _mapper.Map<SelectActorDto>(result);
        }

        public async Task<IEnumerable<SelectActorDto>> GetAllActorsAsync()
        {
            var actors = await _context.Actors
                  .Include(a => a.Person)
                  .Include(a => a.MovieActors)
                  .ThenInclude(ma => ma.Movie)
                  .ToListAsync();

            // Mapleme işlemi
            return _mapper.Map<IEnumerable<SelectActorDto>>(actors);
        }

        public async Task<Actor> UpdateActorAsync(UpdateActorDto updateActorDto)
        {
            var actor = await _context.Actors.Include(a => a.Person).FirstOrDefaultAsync(a => a.Id == updateActorDto.Id);
            if (actor == null)
                throw new Exception("Actor is could not be find!"); // Eğer Actor bulunamazsa null döner

            // 2. Güncelleme işlemi
            actor.Person.Name = updateActorDto.Name;
            actor.Person.BirthDate = updateActorDto.BirthDate;
            actor.Person.Phone = updateActorDto.Phone;

            _context.Actors.Update(actor); // Değişiklikleri işaretle
            await _context.SaveChangesAsync(); // Veritabanına uygula

            return actor;
        }

        
    }
}
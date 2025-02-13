using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MovieStoreApi.Dtos.GenreDtos;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class GenreService : IGenreService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GenreService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateGenreDto> AddGenreAsync(CreateGenreDto genre)
        {
            var result = _mapper.Map<Genre>(genre);
            await _context.Genres.AddAsync(result);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> DeleteGenreAsync(Guid id)
        {
            var find = await _context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
            if (find == null)
                throw new Exception("Genre not found!");
            _context.Genres.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SelectGenreDto>> GetAllGenreAsync()
        {
            var genres = await _context.Genres
                                            .Include(a => a.CustomerFavoriteGenres)
                                                .ThenInclude(a => a.Customer)
                                                .ThenInclude(a => a.Person)
                                            .Include(a => a.MovieGenres)
                                                .ThenInclude(a => a.Movie)
                                            .ToListAsync();
            return _mapper.Map<IEnumerable<SelectGenreDto>>(genres);
        }

        public async Task<SelectGenreDto?> GetGenreByIdAsync(Guid id)
        {
            var genresById = await _context.Genres.
                                            Include(a => a.CustomerFavoriteGenres).
                                                ThenInclude(a => a.Customer).
                                                ThenInclude(a => a.Person)
                                            .Include(a => a.MovieGenres)
                                                .ThenInclude(a => a.Movie)
                                            .FirstOrDefaultAsync(a => a.Id == id);
            if (genresById == null)
                throw new Exception("Genres Not Found!");
            return _mapper.Map<SelectGenreDto>(genresById);
        }

        public async Task<bool> UpdateGenreAsync(UpdateGenreDto genre)
        {
            var genres = await _context.Genres.FindAsync(genre.Id);
            if (genres == null)
                throw new Exception("Genre Not Found!");

            genres.Name = genre.Name;
            genres.Description = genre.Description;
            _context.Genres.Update(genres);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
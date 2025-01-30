using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieStoreApi.Dtos.MovieDtos;
using MovieStoreApi.Entities;
using MovieStoreApi.Repository.Context;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MovieService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateMovieDto> AddMovieAsync(CreateMovieDto movie)
        {
            var resultMovie = _mapper.Map<Movie>(movie);
            await _context.Movies.AddAsync(resultMovie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var resultMovie = await _context.Movies.FirstOrDefaultAsync(a=> a.Id == id);
            if(resultMovie == null)
                throw new Exception("Movie is could not find!");
            _context.Movies.Remove(resultMovie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SelectMovieDto>> GetAllMovieAsync()
        {
           var resultMovie = await _context.Movies
                                .Include(a => a.Director)
                                    .ThenInclude(a=> a.person)
                                .Include(a=>a.movieActors)
                                    .ThenInclude(ma => ma.Actor)
                                    .ThenInclude(ap => ap.Person)
                                .ToListAsync();
           return _mapper.Map<IEnumerable<SelectMovieDto>>(resultMovie);
        }

        public async Task<SelectMovieDto?> GetMovieByIdAsync(int id)
        {
            var resultMovie = await _context.Movies
                                    .Include(a=>a.Director)
                                        .ThenInclude(b=>b.person)
                                    .Include(c=>c.movieActors)
                                        .ThenInclude(d=>d.Actor)
                                        .ThenInclude(e=>e.Person)
                                    .FirstOrDefaultAsync(a=> a.Id == id);
            if(resultMovie == null)
                throw new Exception("Movie is could not be find!");

            return _mapper.Map<SelectMovieDto>(resultMovie);
        }

        public async Task<bool> UpdateMovieAsync(UpdateMovieDto movie)
        {
            var resultMovie = await _context.Movies.FirstOrDefaultAsync(mov => mov.Id == movie.Id);
            if(resultMovie == null)
                throw new Exception("Movie is could not be find!");

            _mapper.Map(movie, resultMovie); // movie'den resultMovie'ye değerleri aktar
            _context.Movies.Update(resultMovie); 
            await _context.SaveChangesAsync();
            return true;
            
        }
    }
}
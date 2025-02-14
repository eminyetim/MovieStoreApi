using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieStoreApi.Dtos.MovieActorsDtos;
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
            var resultMovie = await _context.Movies.FirstOrDefaultAsync(a => a.Id == id);
            if (resultMovie == null)
                throw new Exception("Movie is could not find!");
            _context.Movies.Remove(resultMovie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SelectMovieDto>> GetAllMovieAsync()
        {
            var resultMovie = await _context.Movies
                                 .Include(a => a.Director)
                                     .ThenInclude(a => a.person)
                                 .Include(a => a.movieActors)
                                     .ThenInclude(ma => ma.Actor)
                                     .ThenInclude(ap => ap.Person)
                                 .Include(a => a.movieGenre)
                                    .ThenInclude(b => b.Genre)
                                 .ToListAsync();
            return _mapper.Map<IEnumerable<SelectMovieDto>>(resultMovie);
        }

        public async Task<SelectMovieDto?> GetMovieByIdAsync(int id)
        {
            var resultMovie = await _context.Movies
                                    .Include(a => a.Director)
                                        .ThenInclude(b => b.person)
                                    .Include(c => c.movieActors)
                                        .ThenInclude(d => d.Actor)
                                        .ThenInclude(e => e.Person)
                                    .FirstOrDefaultAsync(a => a.Id == id);
            if (resultMovie == null)
                throw new Exception("Movie is could not be find!");

            return _mapper.Map<SelectMovieDto>(resultMovie);
        }

        public async Task<bool> UpdateMovieAsync(UpdateMovieDto movie)
        {
            var resultMovie = await _context.Movies.FirstOrDefaultAsync(mov => mov.Id == movie.Id);
            if (resultMovie == null)
                throw new Exception("Movie is could not be find!");

            _mapper.Map(movie, resultMovie); // movie'den resultMovie'ye değerleri aktar
            _context.Movies.Update(resultMovie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddActorsToMovie([FromBody] AddMovieActorsDto dto)
        {
            var movie = await _context.Movies.Include(m => m.movieActors).FirstOrDefaultAsync(m => m.Id == dto.MovieId);

            if (movie == null)
                throw new Exception($"No Movie with ID {dto.MovieId} found");

            foreach (var actorDto in dto.Actors)
            {
                var actorExists = await _context.Actors.AnyAsync(a => a.Id == actorDto.ActorId);
                if (!actorExists)
                    throw new Exception($"No Actor with ID {actorDto.ActorId} found");

                bool alreadyAdded = movie.movieActors.Any(ma => ma.ActorId == actorDto.ActorId);
                if (alreadyAdded)
                    continue;

                var movieActors = new MovieActor
                {
                    MovieId = dto.MovieId,
                    ActorId = actorDto.ActorId,
                    Role = actorDto.Role
                };

                movie.movieActors.Add(movieActors);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddToGenreForMovie(int movieId, Guid genreId)
        {
            var movieExists = await _context.Movies.AnyAsync(mv => mv.Id == movieId);
            if (!movieExists)
                throw new Exception("Movie Not Found!");
            var genreExists = await _context.Genres.AnyAsync(gnr => gnr.Id == genreId);
            if (!genreExists)
                throw new Exception("Genre Not Found!");

            var MovieGenre = await _context.MovieGenres.FirstOrDefaultAsync(mgr => mgr.MovieId == movieId && mgr.GenreId == genreId);
            if (MovieGenre != null)
                throw new Exception("This Genre is already the Movie's genre");

            var newMovieGenre = new MovieGenre
            {
                MovieId = movieId,
                GenreId = genreId
            };

            await _context.MovieGenres.AddAsync(newMovieGenre);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromGenreForMovie(int movieId, Guid genreGuid)
        {
            var MovieGenre = await _context.MovieGenres.FirstOrDefaultAsync(mgr => mgr.MovieId == movieId && mgr.GenreId == genreGuid);
            if (MovieGenre == null)
                throw new Exception("This Genre is not the movie's genre!");
            _context.MovieGenres.Remove(MovieGenre);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Dtos.ActorDtos;
using MovieStoreApi.Dtos.MovieActorsDtos;
using MovieStoreApi.Dtos.MovieDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IMovieService
    {
        Task<IEnumerable<SelectMovieDto>> GetAllMovieAsync();
        Task<SelectMovieDto?> GetMovieByIdAsync(int id);
        Task<CreateMovieDto> AddMovieAsync(CreateMovieDto movie);
        Task<bool> UpdateMovieAsync(UpdateMovieDto movie);
        Task<bool> DeleteMovieAsync(int id);
        Task<bool> AddActorsToMovie([FromBody] AddMovieActorsDto dto);
        Task<bool> AddToGenreForMovie(int movieId, Guid genreId);
        Task<bool> RemoveFromGenreForMovie(int movieId, Guid genreGuid);
    }
}
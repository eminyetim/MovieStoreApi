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
    }
}
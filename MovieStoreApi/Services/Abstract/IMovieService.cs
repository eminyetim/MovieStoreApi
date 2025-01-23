using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovieAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
    }
}
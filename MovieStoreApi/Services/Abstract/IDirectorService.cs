using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IDirectorService
    {
        Task<IEnumerable<Director>> GetAllDirectorsAsync();
        Task<Director?> GetDirectorByIdAsync(int id);
        Task<Director> AddDirectorAsync(Director director);
        Task UpdateDirectorAsync(Director director);
        Task DeleteDirectorAsync(int id);
    }
}
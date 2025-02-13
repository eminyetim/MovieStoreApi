using MovieStoreApi.Dtos.GenreDtos;

namespace MovieStoreApi.Services.Abstract
{
    public interface IGenreService
    {
        Task<IEnumerable<SelectGenreDto>> GetAllGenreAsync();
        Task<SelectGenreDto?> GetGenreByIdAsync(Guid id);
        Task<CreateGenreDto> AddGenreAsync(CreateGenreDto genre);
        Task<bool> UpdateGenreAsync(UpdateGenreDto genre);
        Task<bool> DeleteGenreAsync(Guid id);
    }
}
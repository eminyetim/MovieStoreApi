using MovieStoreApi.Dtos.DirectorDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IDirectorService
    {
        Task<IEnumerable<SelectDirectorDto>> GetAllDirectorsAsync();
        Task<SelectDirectorDto?> GetDirectorByIdAsync(int id);
        Task<CreateDirectorDto> AddDirectorAsync(CreateDirectorDto director);
        Task<bool> UpdateDirectorAsync(UpdateDirectorDto director);
        Task<bool> DeleteDirectorAsync(int id);
    }
}
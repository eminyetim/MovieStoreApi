using MovieStoreApi.Dtos.CustomerDtos;
using MovieStoreApi.Dtos.GenreDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<SelectCustomerDto>> GetAllCustomersAsync();
        Task<SelectCustomerDto?> GetCustomerByIdAsync(int id);
        Task<CreateCustomerDto> AddCustomerAsync(CreateCustomerDto customer);
        Task<bool> UpdateCustomerAsync(UpdateCustomerDto customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> AddToGenreFavoriteForCustomerAsync(int customerId, Guid genreId);
        Task<bool> RemoveFromGenreForCustomerAsync(int customerId, Guid genreGuid);
        Task<bool> PurchaseMovieAsync(int customerId, int MovieId);
    }
}
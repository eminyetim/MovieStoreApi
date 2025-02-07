using MovieStoreApi.Dtos.CustomerDtos;
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
    }
}
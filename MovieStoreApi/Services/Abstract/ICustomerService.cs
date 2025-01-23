using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomerrsAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}
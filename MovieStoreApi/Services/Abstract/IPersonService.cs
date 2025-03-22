using MovieStoreApi.Dtos.PersonDto;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IPersonService
    {
        Task<IEnumerable<SelectPersonDto?>> GetAllPersonsAsync();
        Task<SelectPersonDto?> GetPersonByEmailAsync(string email);
        Task<CreatePersonDto> AddPersonAsync(CreatePersonDto person);
        Task UpdatePersonAsync(UpdatePersonDto person);
        Task DeletePersonAsync(string email);
    }
}
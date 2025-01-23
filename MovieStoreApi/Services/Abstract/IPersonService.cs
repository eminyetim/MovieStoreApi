using MovieStoreApi.Dtos.PersonDto;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IPersonService
    {
        Task<IEnumerable<SelectPersonDto>> GetAllPersonsAsync();
        Task<SelectPersonDto?> GetPersonByIdAsync(int id);
        Task<CreatePersonDto> AddPersonAsync(CreatePersonDto person);
        Task UpdatePersonAsync(UpdatePersonDto person);
        Task DeletePersonAsync(int id);
    }
}
using MovieStoreApi.Dtos.ActorDtos;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IActorService
    {
        Task<IEnumerable<SelectActorDto>> GetAllActorsAsync();
        Task<SelectActorDto?> GetActorByIdAsync(int id);
        Task<CreateActorDto> AddActorAsync(CreateActorDto director);
        Task<Actor> UpdateActorAsync(UpdateActorDto director);
        Task<bool> DeleteActor(int id);
    }   
}
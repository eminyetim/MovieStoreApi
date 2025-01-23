using MovieStoreApi.Entities;

namespace MovieStoreApi.Services.Abstract
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor?> GetActorByIdAsync(int id);
        Task<Actor> AddActorAsync(Actor director);
        Task UpdateActorAsync(Actor director);
        Task DeletePersonAsync(int id);
    }   
}
using MovieStoreApi.Entities;
using MovieStoreApi.Services.Abstract;

namespace MovieStoreApi.Services.Concrete
{
    public class ActorService : IActorService
    {
        public Task<Actor> AddActorAsync(Actor director)
        {
            throw new NotImplementedException();
        }

        public Task DeletePersonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Actor?> GetActorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateActorAsync(Actor director)
        {
            throw new NotImplementedException();
        }
    }
}
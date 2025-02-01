using MovieStoreApi.Entities;

namespace MovieStoreApi.Dtos.MovieActorsDtos
{
    public class SelectMovieActorDto
    {
        public string? MoviName { get; set; }
        public List<Actor> actors {get;set;} = new();
    }
}
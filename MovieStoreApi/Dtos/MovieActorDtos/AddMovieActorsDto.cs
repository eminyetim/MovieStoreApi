using MovieStoreApi.Entities;

namespace MovieStoreApi.Dtos.MovieActorsDtos
{
    public class AddMovieActorsDto
    {
        public int MovieId {get;set;}
        public List<MovieActorsDto> Actors {get;set;} = new();
    }
}
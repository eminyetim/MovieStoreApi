using MovieStoreApi.Entities;

namespace MovieStoreApi.Dtos.ActorDtos
{
    public class SelectActorDto
    {

        public int Id { get; set; } // Actor ID
        public string Name { get; set; } = null!; // Actor Name (from Person)
        public DateTime BirthDate { get; set; } // BirthDate (from Person)
        public string? Phone { get; set; } // Phone (from Person)
        public List<string> MoviesName { get; set; } = new List<string>(); // Sadece film adlarını tutmak için
    }

}
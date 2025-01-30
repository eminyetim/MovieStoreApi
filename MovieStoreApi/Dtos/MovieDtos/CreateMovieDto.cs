namespace MovieStoreApi.Dtos.MovieDtos
{
    public class CreateMovieDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
    }
}
namespace MovieStoreApi.Dtos.MovieDtos
{
    public class SelectMovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string DirectorName { get; set; }
        public List<string> Actor { get; set; } = new List<string>(); // Film adlarını tutar
    }
}
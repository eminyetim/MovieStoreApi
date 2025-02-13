namespace MovieStoreApi.Dtos.GenreDtos
{
    public class SelectGenreDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<string> MovieGenres { get; set; } = new List<string>();

        public ICollection<string> CustomerFavoriteGenres { get; set; } = new List<string>();
    }
}
namespace MovieStoreApi.Dtos.GenreDtos
{
    public class UpdateGenreDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
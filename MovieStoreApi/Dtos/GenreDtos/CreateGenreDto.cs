namespace MovieStoreApi.Dtos.GenreDtos
{
    public class CreateGenreDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
namespace MovieStoreApi.Dtos.DirectorDtos
{
    public class CreateDirectorDto
    {
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
    }
}
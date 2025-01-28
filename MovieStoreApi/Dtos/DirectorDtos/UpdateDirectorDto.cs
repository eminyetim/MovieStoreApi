namespace MovieStoreApi.Dtos.DirectorDtos
{
    public class UpdateDirectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
    }
}
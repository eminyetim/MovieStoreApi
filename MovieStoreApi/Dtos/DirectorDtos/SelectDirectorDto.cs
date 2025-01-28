using MovieStoreApi.Entities;

namespace MovieStoreApi.Dtos.DirectorDtos
{
    public class SelectDirectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
        public List<string> Movies { get; set; } = new List<string>(); // Film adlarını tutar
    }
}
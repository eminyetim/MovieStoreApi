
namespace MovieStoreApi.Dtos.ActorDtos
{
    public class CreateActorDto
    {
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
    }
}
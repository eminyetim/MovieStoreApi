namespace MovieStoreApi.Dtos.ActorDtos
{
    public class UpdateActorDto
    {
        public int Id {get;set;}
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = null!;
    }
}
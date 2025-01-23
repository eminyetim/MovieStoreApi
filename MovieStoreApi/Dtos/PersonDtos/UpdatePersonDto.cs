namespace MovieStoreApi.Dtos.PersonDto
{
    public class UpdatePersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }
    }
}
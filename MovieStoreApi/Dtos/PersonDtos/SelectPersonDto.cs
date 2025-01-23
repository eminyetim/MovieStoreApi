namespace MovieStoreApi.Dtos.PersonDto
{
    public class SelectPersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }

        public DateTime CreateDate { get; }
    }
}
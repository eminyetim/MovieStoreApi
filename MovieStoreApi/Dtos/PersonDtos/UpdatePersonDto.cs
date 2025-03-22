namespace MovieStoreApi.Dtos.PersonDto
{
    public class UpdatePersonDto
    {
        public string email { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }
    }
}
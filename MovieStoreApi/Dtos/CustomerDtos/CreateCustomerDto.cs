namespace MovieStoreApi.Dtos.CustomerDtos
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }
    }
}
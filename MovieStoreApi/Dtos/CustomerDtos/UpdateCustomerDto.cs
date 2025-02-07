namespace MovieStoreApi.Dtos.CustomerDtos
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }
    }
}
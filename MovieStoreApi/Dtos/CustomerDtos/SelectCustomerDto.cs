namespace MovieStoreApi.Dtos.CustomerDtos
{
    public class SelectCustomerDto
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }

        public DateTime CreateDate { get; set;}
    }
}

namespace MovieStoreApi.Dtos.PersonDto
{
    public class CreatePersonDto 
    {      
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    
        public string? Phone { get; set; }
    }
}
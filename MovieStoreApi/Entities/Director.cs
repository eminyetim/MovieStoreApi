namespace MovieStoreApi.Entities
{
    public class Director
    {
        public int Id{get;set;}
        public int PersonId{get;set;}
        public Person person{get;set;}
        public ICollection<Movie> Movies {get;set;} = new List<Movie>();
    }
}
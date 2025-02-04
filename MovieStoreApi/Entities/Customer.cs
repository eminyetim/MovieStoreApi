namespace MovieStoreApi.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<CustomerFavoriteGenre> FavoriteGenres { get; set; } = new List<CustomerFavoriteGenre>();

    }
}
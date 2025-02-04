namespace MovieStoreApi.Entities
{
    public class CustomerFavoriteGenre
    {
        public int CustomerFavoriteGenreId { get; set; }
        // Müşteri (Customer) ile ilişki
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // Tür (Genre) ile ilişki: Genre Id'si Guid türünde
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
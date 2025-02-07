namespace MovieStoreApi.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; } = null!;
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public decimal PurchasePrice { get; set; }
    }
}
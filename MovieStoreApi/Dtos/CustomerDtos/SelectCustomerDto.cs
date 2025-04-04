using Microsoft.Identity.Client;

namespace MovieStoreApi.Dtos.CustomerDtos
{
    public class SelectCustomerDto
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Phone { get; set; }

        public DateTime CreateDate { get; set; }

        public List<string> FavoriteGenres { get; set; } = new List<string>();

        public List<string> PurchaseMovies { get; set; } = new List<string>();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreApi.Entities
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }

        // Film türleri ile ilişki (çoktan çoğa ilişki için join tablosu)
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

        // Müşteri favori türleri ile ilişki
        public ICollection<CustomerFavoriteGenre> CustomerFavoriteGenres { get; set; } = new List<CustomerFavoriteGenre>();
    }
}
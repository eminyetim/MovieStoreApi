namespace MovieStoreApi.Entities
{
    public class MovieGenre
    {
        public int MovieGenreId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        // Tür (Genre) entity'sinde tanımladığımız GUID tipi kullanılıyor.
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
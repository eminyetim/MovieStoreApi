using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MovieStoreApi.Entities
{
    public class Movie
    {
        public int Id {get;set;}
        
        [MaxLength(100)]
        public string Name{get;set;}
        public DateTime ReleaseDate {get;set;}

        [Precision(18, 2)] // Decimal hassasiyetini ayarla
        public decimal Price{get;set;}
        public int DirectorId{get;set;}
        public Director Director{get;set;} = null!;

        public ICollection<MovieActor> movieActors{get;set;} = new List<MovieActor>();
    }
}